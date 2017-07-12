using System;
using System.Linq;
using Vidly.Models;
using System.Web.Mvc;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class FilmesController : Controller
    {
        private ApplicationDbContext _context;

        public FilmesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Filmes/Aleatorio
        public ActionResult Aleatorio()
        {
            var filme = _context.Filmes.ElementAt(new Random().Next(_context.Filmes.Count()));
            var clientes = _context.Clientes.ToList();

            var viewModel = new FilmeAleatorioViewModel
            {
                Filme = filme,
                Clientes = clientes
            };

            return View(viewModel);
        }

        public ViewResult Index()
        {
            var filmes = _context.Filmes.Include(f => f.Genero);
            return View(filmes);
        }

        public ActionResult Detalhes(int id)
        {
            var filme = _context.Filmes.Include(f => f.Genero).SingleOrDefault(c => c.Id == id);

            if (filme == null)
                return HttpNotFound("Filme não encontrado!");

            return View(filme);
        }
    }
}