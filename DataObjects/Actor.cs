using System;
using System.Collections.Generic;

namespace WinForms_EntityFramework.DataObjects;

public partial class Actor
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Filmactor> Filmactors { get; set; } = new List<Filmactor>();
}
