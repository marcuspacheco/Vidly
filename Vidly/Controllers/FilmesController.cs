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
        private ApplicationDbContext _contexto;

        public FilmesController()
        {
            _contexto = new ApplicationDbContext();
        }

        // GET: Filmes/Aleatorio
        public ActionResult Aleatorio()
        {
            var filme = _contexto.Filmes.ElementAt(new Random().Next(_contexto.Filmes.Count()));
            var clientes = _contexto.Clientes.ToList();

            var viewModel = new FilmeAleatorioViewModel
            {
                Filme = filme,
                Clientes = clientes
            };

            return View(viewModel);
        }

        public ViewResult Index()
        {
            var filmes = _contexto.Filmes.Include(f => f.Genero);
            return View(filmes);
        }

        public ActionResult Detalhes(int id)
        {
            var filme = _contexto.Filmes.Include(f => f.Genero).SingleOrDefault(c => c.Id == id);

            if (filme == null)
                return HttpNotFound("Filme não encontrado!");

            return View(filme);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Salvar(Filme filme)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FilmeFormularioViewModel(filme)
                {
                    Generos = _contexto.Generos.ToList()
                };

                return View("FormularioFilme", viewModel);
            }

            if (filme.Id == 0)
            {
                filme.DataAdicionado = DateTime.Now;
                _contexto.Filmes.Add(filme);
            }
            else
            {
                var filmeNoBanco = _contexto.Filmes.Single(c => c.Id == filme.Id);
                //TryUpdateModel(filmeNoBanco);
                filmeNoBanco.Nome = filme.Nome;
                filmeNoBanco.DataDeLancamento = filme.DataDeLancamento;
                filmeNoBanco.DataAdicionado = filme.DataAdicionado;
                filmeNoBanco.NumeroEmEstoque = filme.NumeroEmEstoque;
                filmeNoBanco.GeneroId = filme.GeneroId;
            }
            _contexto.SaveChanges();
            return RedirectToAction("Index", "Filmes");
        }

        public ActionResult Novo()
        {
            var generos = _contexto.Generos.ToList();
            var viewModel = new FilmeFormularioViewModel()
            {
                Generos = generos,
            };
            return View("FormularioFilme", viewModel);
        }

        public ActionResult Editar(int id)
        {
            var filme = _contexto.Filmes.SingleOrDefault(c => c.Id == id);
            if (filme == null)
                return HttpNotFound("Filme não encontrado!");

            var viewModel = new FilmeFormularioViewModel(filme)
            {
                Generos = _contexto.Generos.ToList()
            };

            return View("FormularioFilme", viewModel);

        }
    }
}