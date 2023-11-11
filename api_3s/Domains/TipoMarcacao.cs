using System;
using System.Collections.Generic;

namespace api_3s.Domains;

public partial class TipoMarcacao
{
    public byte IdTipoMarcacao { get; set; }

    public string TipoMarcacao1 { get; set; } = null!;

    public virtual ICollection<Marcacao> Marcacaos { get; set; } = new List<Marcacao>();
}
