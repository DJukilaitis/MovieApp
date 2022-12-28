namespace MovieApp.Models.ViewModel
{
    public class MovieDTO
    {

            public int MovieId { get; set; }

            public string Description { get; set; } = null!;

            public DateTime Date { get; set; }

            public string Genre { get; set; }

            public string Name { get; set; } = null!;


    }
}
