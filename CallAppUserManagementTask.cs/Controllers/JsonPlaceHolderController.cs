using CallAppUserManagementTask.cs.Data;
using CallAppUserManagementTask.cs.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace CallAppUserManagementTask.cs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JsonPlaceHolderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        public JsonPlaceHolderController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("GetUserPostsAndCommentsById/{id}")]
        public async Task<IActionResult> GetUserPostsAndCommentsById(int id)
        {
            var user=_context.Users.Where(u=>u.id==id).FirstOrDefault();
            if (user == null)
            {
                return NotFound("ჩანაწერი ვერ მოიძებნა");
            }
            var apiUrl = "https://jsonplaceholder.typicode.com/users/" + id + "/posts/";
            using var httpClient = _httpClientFactory.CreateClient();
            try
            {
                var response = await httpClient.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {                 
                    var content = await response.Content.ReadAsStringAsync();
                    if (String.IsNullOrEmpty(content))
                    {
                        return NotFound("ჩანაწერი ვერ მოიძებნა");
                    }
                    var deserialisedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PostsDTO>>(content);
                    var postAndCommentsDtos = new List<PostsAndCommentDTO>();

                    if (deserialisedJson != null && deserialisedJson.Count > 0)
                    {
                        foreach (var deserialisedObject in deserialisedJson)
                        {
                            var postAndCommentsDto = new PostsAndCommentDTO();
                            postAndCommentsDto.title = deserialisedObject.title;
                            postAndCommentsDto.userid = deserialisedObject.userid;
                            postAndCommentsDto.body = deserialisedObject.body;
                            postAndCommentsDto.id = deserialisedObject.id;

                            var commentUrl = "https://jsonplaceholder.typicode.com/posts/" + deserialisedObject.id + "/comments/";
                            var commentResponse = await httpClient.GetAsync(commentUrl);
                            if (commentResponse.IsSuccessStatusCode)
                            {
                                var comments = await response.Content.ReadAsStringAsync();

                                postAndCommentsDto.comments = comments;


                            }
                            postAndCommentsDtos.Add(postAndCommentsDto);
                        }

                        var postsAndCommentsJson = JsonConvert.SerializeObject(postAndCommentsDtos);
                        return Ok(postsAndCommentsJson);
                    }



                }
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
            catch (HttpRequestException ex)
            {

                return StatusCode(500, $"Error communicating with the API: {ex.Message}");
            }
        }
        [HttpGet("GetUserTodoById/{id}")]
        public async Task<IActionResult> GetUserTodoById(int id)
        {
            var user = _context.Users.Where(u => u.id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound("ჩანაწერი ვერ მოიძებნა");
            }
            var apiUrl = "https://jsonplaceholder.typicode.com/users/" + id + "/todos/";
            return await GetUserResourceById(id, apiUrl);
        }

        [HttpGet("GetUserPhotoById/{id}")]
        public async Task<IActionResult> GetUserPhotoById(int id)
        {
            var user = _context.Users.Where(u => u.id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound("ჩანაწერი ვერ მოიძებნა");
            }
            var apiUrl = "https://jsonplaceholder.typicode.com/users/" + id + "/albums/";
            return await GetUserResourceById(id, apiUrl);
        }

        private async Task<IActionResult> GetUserResourceById(int id, string apiUrl)
        {
            using var httpClient = _httpClientFactory.CreateClient();

            try
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                     
                        return NotFound("ჩანაწერი ვერ მოიძებნა");
                    }
                  
                    return Ok(content);
                }

                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error communicating with the API: {ex.Message}");
            }
        }
    }
}
