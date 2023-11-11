using api_3s.Domains;

namespace api_3s.Application.ViewModel;

public class FuncionarioViewModel
{
    public byte IdTipoUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public byte IdCargo { get; set; }
}
