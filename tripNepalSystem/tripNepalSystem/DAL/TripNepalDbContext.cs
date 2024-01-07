using Microsoft.EntityFrameworkCore;
using tripNepalSystem.Model;

namespace tripNepalSystem.DAL;

    public class TripNepalDbContext:DbContext
    {
        public TripNepalDbContext(DbContextOptions<TripNepalDbContext>options):base(options) 
        {
        }  
        public DbSet<Destination> Destinations { get; set; }   
         public DbSet<Map>  Maps { get; set; }

    }

