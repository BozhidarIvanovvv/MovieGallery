using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieGalleryApp.Infrastructure.Identity;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieCountry> MovieCountries { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCinema> MovieCinemas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            builder
                .Entity<MovieCountry>()
                .HasKey(mc => new { mc.MovieId, mc.CountryId });

            builder
                .Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            builder
                .Entity<MovieCinema>()
                .HasKey(ma => new { ma.MovieId, ma.CinemaId });
        }
    }
}