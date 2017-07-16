using Vidly.Models;
using System.Collections.Generic;

namespace Vidly.ViewModels
{
    public class ClienteFormularioViewModel
    {
        public IEnumerable<TipoAssinatura> TipoAssinaturas { get; set; }
        public Cliente Cliente { get; set; }
    }
}