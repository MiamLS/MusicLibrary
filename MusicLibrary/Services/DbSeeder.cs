using MusicLibrary.Data;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public class DbSeeder
    {
        public static void SeedUsers(MusicDBContext context)
        {
            // Only seed if database is empty
            if (context.Users.Any())
                return;

            var users = new List<User>
            {
                new User 
                {
                    Username = "admin",
                    PasswordHash = AuthService.HashPassword("1234"),
                    Role = "Admin"
                },
                new User
                {
                    Username = "Okan",
                    PasswordHash = AuthService.HashPassword("4321"),
                    Role = "User"
                },
                new User
                {
                    Username = "Kasper",
                    PasswordHash = AuthService.HashPassword("4321"),
                    Role = "User"
                }
                ,
                new User
                {
                    Username = "Amjad",
                    PasswordHash = AuthService.HashPassword("4321"),
                    Role = "User"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
