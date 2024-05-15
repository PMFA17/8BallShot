using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _8BallShot.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NIF { get; set; }
    }
}
