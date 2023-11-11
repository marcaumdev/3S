using System;
using System.Collections.Generic;

namespace api_3s.Domains;

public partial class Usuario
{
    public Usuario(byte idTipoUsuario, string nome, string cpf, string senha, string email)
    {
        IdTipoUsuario = idTipoUsuario;
        Nome = nome;
        Cpf = cpf;
        Senha = senha;
        Email = email;
    }

    public int IdUsuario { get; set; }

    public byte IdTipoUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string QrCode { get; set; } = null!;

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; } = null!;
}
