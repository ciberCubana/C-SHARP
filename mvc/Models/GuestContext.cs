using Microsoft.EntityFrameworkCore;


namespace mvc.Models
{
    public class GuestContext1 : DbContext
    {
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Budget> Budget{get;set;}
        public DbSet<TimeLine> TimeLine {get;set;}
        public DbSet<TODO> TODO {get;set;}
       


       

        public GuestContext1(DbContextOptions<GuestContext1> options)
            : base(options) { }
    }
}