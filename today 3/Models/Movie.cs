using System.Collections.Generic;

namespace toss2.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public List<Actor> Cast { get; set; }

        public Movie()
        {
            this.Cast = new List<Actor>();
        }
    }
}