using System;
using System.Collections.Generic;

namespace MovieApp.Models;

public partial class Actor
{
    public int ActorId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MovieActor> MovieActors { get; } = new List<MovieActor>();
}
