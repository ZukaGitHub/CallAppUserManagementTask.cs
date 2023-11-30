application follows Code-First Workflow,uses .Net 6 Web Api
in Data folder there is AppDbContext.cs where Seed method is defined,with values extracted from JsonPlaceHolder for convinience
Navigate to Tools>Package Manager Console
write add-migration
choose name
update-database
after this comment out Seed(modelbuilder) in AppDbContext
after building and running the application there are several things to keep in mind
1) only UsersController requires authorisation
2) to authorise use any userName  from JsonPaceHolder from first 5 entries (e.g Bret) and Password1! as password
3) copy the response token into swagger authorise modal
4) enjoy :)
