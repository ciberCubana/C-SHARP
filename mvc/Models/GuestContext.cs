using Microsoft.EntityFrameworkCore;


namespace mvc.Models
{
    public class GuestContext1 : DbContext
    {
        public DbSet<Guest> Guest { get; set; }
       

        public GuestContext1(DbContextOptions<GuestContext1> options)
            : base(options) { }
    }
}