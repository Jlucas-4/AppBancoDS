using AppBancoLM.Models;
using AppBancoLM.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppBancoLM.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController (IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult CadastrarUsuario()
        {
            return View();
        }
        
        [HttpPost]

        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                _usuarioRepository.Cadastrar(usuario);
            }
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
