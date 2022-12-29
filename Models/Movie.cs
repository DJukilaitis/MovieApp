using System;
using System.Collections.Generic;

namespace MovieApp.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public int LeadActorId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual Actor LeadActor { get; set; } = null!;
}
