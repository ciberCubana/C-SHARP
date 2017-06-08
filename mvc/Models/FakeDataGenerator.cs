using System.Collections.Generic;
using System.Linq;
using Bogus;


namespace mvc.Models
{
    public class FakeDataGenerator
    {
        public static IEnumerable<Guest> GenerateFakeGuest()
        {
            var guestFaker = new Faker<Guest>();
           var quantity = 100;
            // var actorFaker = new Faker<Guest>()
            //                     .RuleFor(g => g.nameGuest, f => f.Name.FirstName() + " " + f.Name.LastName())
            //                     .RuleFor(a => a.DateOfBirth, f => f.Date.Past(30));


            return guestFaker
                  .RuleFor(g => g.nameGuest, f => f.Name.FirstName() + " " + f.Name.LastName())
                  .RuleFor(g => g.email, f => f.Internet.Email())
                //   .RuleFor(g => g.ReleaseYear, f => f.Date.Past(5).Year)
                //   .RuleFor(g => g.Cast, f => actorFaker.Generate(5).ToList())
                  .Generate(quantity);
        }
    }
}