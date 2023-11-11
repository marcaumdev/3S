using System;
using System.Collections.Generic;

namespace api_3s.Domains;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public int IdUsuario { get; set; }

    public byte IdCargo { get; set; }

    public string EmailEmpresarial { get; set; } = null!;

    public bool Ativo { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Marcacao> Marcacaos { get; set; } = new List<Marcacao>();
}
