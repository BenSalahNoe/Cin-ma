using System;
using System.Collections.Generic;

namespace WinForms_EntityFramework.DataObjects;

public partial class Director
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Filmdirector> Filmdirectors { get; set; } = new List<Filmdirector>();
}
