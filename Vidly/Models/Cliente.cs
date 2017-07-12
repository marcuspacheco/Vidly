using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Nome { get; set; }
        public bool EhInscritoNaNewsletter { get; set; }
        public TipoAssinatura TipoAssinatura { get; set; }
        public byte TipoAssinaturaId { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}