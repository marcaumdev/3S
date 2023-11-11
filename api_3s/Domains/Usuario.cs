using System;
using System.Collections.Generic;

namespace api_3s.Domains;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public byte IdTipoUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string QrCode { get; set; } = null!;

    public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; } = null!;
}
