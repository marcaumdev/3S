using api_3s.Contexts;
using api_3s.Domains;
using api_3s.Interface;

namespace api_3s.Infraestrutura;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly Context3S _connection = new();

    public void CadastrarFuncionario(Usuario usuario, Funcionario funcionario)
    {
        usuario.QrCode = "teste";
        _connection.Usuarios.Add(usuario);
        _connection.SaveChanges();

        funcionario.IdUsuario = usuario.IdUsuario;
        funcionario.EmailEmpresarial = $"{usuario.IdUsuario}{usuario.Nome}@3s.com";

        _connection.Funcionarios.Add(funcionario);

        _connection.SaveChanges();
    }

    public void CadastrarVisitante(Usuario usuario)
    {
        usuario.QrCode = "teste";
        _connection.Usuarios.Add(usuario);
        _connection.SaveChanges();
    }
}
