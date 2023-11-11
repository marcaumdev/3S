using System;
using System.Collections.Generic;

namespace api_3s.Domains;

public partial class Marcacao
{
    public long IdMarcacao { get; set; }

    public byte IdTipoMarcacao { get; set; }

    public int IdFuncionario { get; set; }

    public DateTime DataHora { get; set; }

    public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;

    public virtual TipoMarcacao IdTipoMarcacaoNavigation { get; set; } = null!;
}
