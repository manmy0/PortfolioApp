using Microsoft.AspNetCore.Identity;

namespace PortfolioApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Degree { get; set; }

        public string? Introduction { get; set; }

        public string? Pitch { get; set; }

        public string? Resume { get; set; }

        public string? CoverLetter { get; set; }

        public string? LinkedIn { get; set; }

        public string? Certificates { get; set; }

        public string? Specialisation { get; set; }

        public byte[]? ProfileImage { get; set; }

    }

}