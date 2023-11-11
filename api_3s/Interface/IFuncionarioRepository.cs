using api_3s.Domains;

namespace api_3s.Interface;

public interface IFuncionarioRepository
{
    public void CadastrarFuncionario(Usuario usuario, Funcionario funcionario);

    public void CadastrarVisitante(Usuario usuario);
}
