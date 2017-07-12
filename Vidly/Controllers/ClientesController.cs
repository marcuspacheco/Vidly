using System.Linq;
using Vidly.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Vidly.Controllers
{
    public class ClientesController : Controller
    {
        public ViewResult Index()
        {
            var clientes = RetornaClientes();
            return View(clientes);
        }

        public ActionResult Detalhes(int id)
        {
            var cliente = RetornaClientes().SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound("Cliente não encontrado!");

            return View(cliente);
        }

        private IEnumerable<Cliente> RetornaClientes()
        {
            return new List<Cliente>
            {
                new Cliente { Id = 1, Nome = "Cliente 1" },
                new Cliente { Id = 2, Nome = "Cliente 2" }
            };
        }
    }
}