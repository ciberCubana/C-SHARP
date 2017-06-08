using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace toss2.Models
{
    public class FakeDataGenerator
    {
        public static IEnumerable<Movie> GenerateFakeMovies()
        {
            var movieFaker = new Faker<Movie>();

            var actorFaker = new Faker<Actor>()
                                .RuleFor(a => a.Name, f => f.Name.FirstName() + " " + f.Name.LastName())
                                .RuleFor(a => a.DateOfBirth, f => f.Date.Past(30));


            return movieFaker
                  .RuleFor(m => m.Title, f => f.Internet.UserName())
                  .RuleFor(m => m.Genre, f => f.Hacker.Noun())
                  .RuleFor(m => m.ReleaseYear, f => f.Date.Past(5).Year)
                  .RuleFor(m => m.Cast, f => actorFaker.Generate(5).ToList())
                  .Generate(20);
        }
    }
}