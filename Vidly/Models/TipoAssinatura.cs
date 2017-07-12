namespace Vidly.Models
{
    public class TipoAssinatura
    {
        public byte Id { get; set; }
        public short ValorInicial { get; set; }
        public byte DuracaoEmMeses { get; set; }
        public byte PorcentagemDesconto { get; set; }

    }
}