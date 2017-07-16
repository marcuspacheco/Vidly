using System;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace Vidly.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Nome { get; set; }
        public Genero Genero { get; set; }
        [Display(Name = "Gênero")]
        public int GeneroId { get; set; }
        [Display(Name = "Data de Lançamento")]
        public DateTime DataDeLancamento { get; set; }
        [Display(Name = "Data de Entrada")]
        public DateTime DataAdicionado { get; set; }
        [Display(Name = "Número em Estoque"), Range(1, 20)]
        public int NumeroEmEstoque { get; set; }

    }
}