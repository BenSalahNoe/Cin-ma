using System;
using System.Collections.Generic;

namespace WinForms_EntityFramework.DataObjects;

public partial class Film
{
    public int Id { get; set; }

    public string Titre { get; set; } = null!;

    public int Annee { get; set; }

    public TimeOnly Duree { get; set; }

    public virtual ICollection<Filmactor> Filmactors { get; set; } = new List<Filmactor>();

    public virtual ICollection<Filmdirector> Filmdirectors { get; set; } = new List<Filmdirector>();
}
