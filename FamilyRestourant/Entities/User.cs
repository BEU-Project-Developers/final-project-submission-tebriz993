using Microsoft.AspNetCore.Identity;

namespace FamilyRestourant.Entities
{
    public class User:IdentityUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
