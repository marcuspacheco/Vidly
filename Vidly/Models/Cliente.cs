namespace Vidly.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool EhInscritoNaNewsletter { get; set; }
        public TipoAssinatura TipoAssinatura { get; set; }
        public byte TipoAssinaturaId { get; set; }
    }
}