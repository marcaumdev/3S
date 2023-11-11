using System;
using System.Collections.Generic;

namespace api_3s.Domains;

public partial class TipoUsuario
{
    public byte IdTipoUsuario { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
