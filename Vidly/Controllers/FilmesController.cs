using System.Linq;
using Vidly.Models;
using System.Web.Mvc;
using Vidly.ViewModels;
using System.Collections.Generic;

namespace Vidly.Controllers
{
    public class FilmesController : Controller
    {
        // GET: Filmes/Aleatorio
        public ActionResult Aleatorio()
        {
            var filme = new Filme() { Nome = "Shrek!" };
            var clientes = new List<Cliente>
            {
                new Cliente{ Nome = "Cliente 1" },
                new Cliente{ Nome = "Cliente 2" },
            };

            var viewModel = new FilmeAleatorioViewModel
            {
                Filme = filme,
                Clientes = clientes
            };

            return View(viewModel);
        }

        public ViewResult Index()
        {
            var filmes = RetornaFilmes();
            return View(filmes);
        }

        public ActionResult Detalhes(int id)
        {
            var cliente = RetornaFilmes().SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound("Filme não encontrado!");

            return View(cliente);
        }

        private IEnumerable<Filme> RetornaFilmes()
        {
            return new List<Filme>
            {
                new Filme { Id = 1, Nome = "Filme 1" },
                new Filme { Id = 2, Nome = "Filme 2" }
            };
        }
    }
}