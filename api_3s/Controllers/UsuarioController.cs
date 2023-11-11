using api_3s.Application.ViewModel;
using api_3s.Domains;
using Microsoft.AspNetCore.Mvc;

namespace api_3s.Controllers;

[ApiController]
[Route("/api/usuario")]
public class UsuarioController : Controller
{
    [HttpPost]
    public IActionResult CadastrarUsuario([FromForm] FuncionarioViewModel funcionarioVM)
    {
        Funcionario funcionario = new(funcionarioVM.IdTipoUsuario, funcionarioVM.Nome, funcionarioVM.Cpf, 
            funcionarioVM.Senha, funcionarioVM.Email, funcionarioVM.IdCargo);

        return Ok();
    }
}
