using System;
using System.Collections.Generic;

namespace api_3s.Domains;

public partial class Cargo
{
    public byte IdCargo { get; set; }

    public string Cargo1 { get; set; } = null!;

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
