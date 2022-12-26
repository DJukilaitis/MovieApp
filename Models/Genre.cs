using System;
using System.Collections.Generic;

namespace MovieApp.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
