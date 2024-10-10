using AppBancoLM.Models;
using AppBancoLM.Repository;
using AppBancoLM.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppBancoLM.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CadastrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Cadastrar(cliente);
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
