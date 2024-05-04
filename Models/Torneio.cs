using System.ComponentModel.DataAnnotations;

namespace _8BallShot.Models
{
    public class Torneio
    {
        [Key]
        public int IdTorneio { get; set; }
        public string NomeTorneio { get; set; }
        public int nFases { get; set; }
        public int nJogadores { get; set; }
        public DateTime DataInicio { get; set; }

    }
}
