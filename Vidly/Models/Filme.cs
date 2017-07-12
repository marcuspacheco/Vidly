using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Nome { get; set; }
        [Required]
        public Genero Genero { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public DateTime DataAdicionado { get; set; }
        public int NumeroEmEstoque { get; set; }

    }
}