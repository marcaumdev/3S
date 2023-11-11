using api_3s.Contexts;
using api_3s.Domains;

namespace api_3s.Infraestrutura;

public class FuncionarioRepository
{
    private readonly Context3S _connection = new();

    public void CadastrarFuncionario(Funcionario funcionario)
    {

    }
}
