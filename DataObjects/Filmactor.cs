using System;
using System.Collections.Generic;

namespace WinForms_EntityFramework.DataObjects;

public partial class Filmactor
{
    public int Id { get; set; }

    public int IdFilm { get; set; }

    public int IdActor { get; set; }

    public virtual Actor IdActorNavigation { get; set; } = null!;

    public virtual Film IdFilmNavigation { get; set; } = null!;
}
