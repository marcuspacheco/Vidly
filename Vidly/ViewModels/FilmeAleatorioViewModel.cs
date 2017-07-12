using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class FilmeAleatorioViewModel
    {
        public Filme Filme { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}