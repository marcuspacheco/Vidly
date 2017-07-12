using System.Linq;
using Vidly.Models;
using System.Web.Mvc;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext _context;

        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        public ViewResult Index()
        {
            var clientes = _context.Clientes.Include(c => c.TipoAssinatura);
            return View(clientes);
        }

        public ActionResult Detalhes(int id)
        {
            var cliente = _context.Clientes.Include(c => c.TipoAssinatura).SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound("Cliente não encontrado!");

            return View(cliente);
        }
    }
}