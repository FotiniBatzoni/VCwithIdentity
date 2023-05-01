using Microsoft.EntityFrameworkCore;
using VideoClubA.Core.Entities;

namespace VideoClubA.Infrastucture.Data
{
    public class VideoClubDbContext : DbContext
    {
        public VideoClubDbContext(DbContextOptions<VideoClubDbContext> options)
        : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        // Add DbSet properties here for each entity
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCopy> MovieCopies { get; set; }
        public DbSet<MovieRent> MovieRents { get; set; }
    }

}
