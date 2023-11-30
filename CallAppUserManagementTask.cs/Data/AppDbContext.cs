using CallAppUserManagementTask.cs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CallAppUserManagementTask.cs.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.userProfile)
                .WithOne(up => up.user)
                .HasForeignKey<UserProfile>(up => up.userid)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<User>().HasData(
                new User { id = 1,username = "Bret",password="Password1!",email = "Sincere@april.biz", isActive = true },
                new User { id = 2, username = "Antonette", password = "Password1!", email = "Shanna@melissa.tv", isActive = true },
                new User { id = 3, username = "Samantha", password = "Password1!", email = "Nathan@yesenia.net", isActive = true },
                new User { id = 4, username = "Karianne", password = "Password1!", email = "Julianne.OConner@kory.org", isActive = true },
                new User { id = 5, username = "Kamren", password = "Password1!", email = "Lucio_Hettinger@annie.ca", isActive = false }


            );

         
            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile { id = 1, firstName = "Leanne", lastName = "Graham", personalNumber = GenerateRandomPersonalNumber(), userid = 1 },
                new UserProfile { id = 2, firstName = "Ervin", lastName = "Howell", personalNumber = GenerateRandomPersonalNumber(), userid = 2 },
                new UserProfile { id = 3, firstName = "Clementine", lastName = "Bauch", personalNumber = GenerateRandomPersonalNumber(), userid = 3 },
                new UserProfile { id = 4, firstName = "Patricia", lastName = "Lebsack", personalNumber = GenerateRandomPersonalNumber(), userid = 4 },
                new UserProfile { id = 5, firstName = "Chelsey", lastName = "Dietrich", personalNumber = GenerateRandomPersonalNumber(), userid = 5 }

            );
        }

        private string GenerateRandomPersonalNumber()
        {

            Random random = new Random();
            long randomNumber = (long)(random.NextDouble() * (99999999999 - 10000000000) + 10000000000);
            return randomNumber.ToString();
        }
    }
}
