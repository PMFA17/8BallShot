using System.ComponentModel.DataAnnotations;

namespace _8BallShot.Models
{
    public class Fases
    {
        [Key]
        public int IdFases { get; set; }
        public string Formato { get; set; }
    }
}
