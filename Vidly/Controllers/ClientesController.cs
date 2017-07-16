using System.Linq;
using Vidly.Models;
using System.Web.Mvc;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext _contexto;

        public ClientesController()
        {
            _contexto = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contexto.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Novo()
        {
            var tipoAssinaturas = _contexto.TipoAssinaturas.ToList();
            var viewModel = new ClienteFormularioViewModel
            {
                TipoAssinaturas = tipoAssinaturas,
                Cliente = new Cliente()
            };
            return View("FormularioCliente", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Salvar(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClienteFormularioViewModel
                {
                    Cliente = cliente,
                    TipoAssinaturas = _contexto.TipoAssinaturas.ToList()
                }
                ;
                return View("FormularioCliente", viewModel);
            }

            if (cliente.Id == 0)
            {
                _contexto.Clientes.Add(cliente);
            }
            else
            {
                var clienteNoBanco = _contexto.Clientes.Single(c => c.Id == cliente.Id);
                //TryUpdateModel(clienteNoBanco);
                clienteNoBanco.Nome = cliente.Nome;
                clienteNoBanco.DataNascimento = cliente.DataNascimento;
                clienteNoBanco.TipoAssinaturaId = cliente.TipoAssinaturaId;
                clienteNoBanco.EhInscritoNaNewsletter = cliente.EhInscritoNaNewsletter;

            }
            _contexto.SaveChanges();
            return RedirectToAction("Index", "Clientes");
        }


        public ActionResult Index()
        {
            var clientes = _contexto.Clientes.Include(c => c.TipoAssinatura);
            return View(clientes);
        }

        public ActionResult Detalhes(int id)
        {
            var cliente = _contexto.Clientes.Include(c => c.TipoAssinatura).SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound("Cliente não encontrado!");

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(int id)
        {
            var cliente = _contexto.Clientes.SingleOrDefault(c => c.Id == id);
            if (cliente == null)
                return HttpNotFound("Cliente não encontrado!");

            var viewModel = new ClienteFormularioViewModel
            {
                Cliente = cliente,
                TipoAssinaturas = _contexto.TipoAssinaturas.ToList()
            };

            return View("FormularioCliente", viewModel);

        }
    }
}