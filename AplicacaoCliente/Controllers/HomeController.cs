using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AplicacaoCliente.Models;

namespace AplicacaoCliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ClienteModel clienteModel = new ClienteModel();
            ViewBag.ListaClientes = clienteModel.ListarTodosClientes();

            return View();
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(ClienteModel dados)
        {
            dados.Inserir();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Registro = new ClienteModel().Carregar(id);
            return View();
        }
        [HttpPost]
        public IActionResult Edit(ClienteModel dados)
        {
            dados.Atualizar();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ClienteModel model = new ClienteModel().Carregar(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(ClienteModel model)
        {
            model.Delete(model.Id);
            return View(nameof(Index));
        }
    }
}
