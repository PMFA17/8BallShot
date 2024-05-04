using System.ComponentModel.DataAnnotations;

namespace _8BallShot.Models
{
    public class Jogador
    {
        [Key]
        public int IdJogador { get; set; }
        public string NomeJogador { get; set; }
        public int NIF { get; set; }
    }
}
