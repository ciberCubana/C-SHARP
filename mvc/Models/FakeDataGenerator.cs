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
           
                                
            var my_status = new[] { "Cancel", "Confirmed"};

            return guestFaker
                  .RuleFor(g => g.nameGuest, f => f.Name.FirstName() + " " + f.Name.LastName())
                  .RuleFor(g => g.email, f => f.Internet.Email())
                  .RuleFor(g => g.status, f => f.PickRandom(my_status))

                  .Generate(200);

                  
        }
    }
}