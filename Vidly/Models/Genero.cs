using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genero
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Nome { get; set; }
    }
}