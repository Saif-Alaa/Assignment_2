using Microsoft.EntityFrameworkCore;
using assigment2.Models;
namespace assigment2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Movie> Movies { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasIndex(n => n.Name)
                .IsUnique();

            modelBuilder.Entity<Movie>()
               .HasIndex(n => n.Title)
               .IsUnique();

            modelBuilder.Entity<Customer>()
               .HasIndex(n => n.Email)
               .IsUnique();

            modelBuilder.Entity<Booking>()
          .Property(n => n.BookingDate)
          .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<Movie>()
          .Property(n => n.TicketPrice)
          .HasPrecision(10, 2);

            modelBuilder.Entity<Genre>()
               .HasIndex(n => n.Name)
               .IsUnique();


            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Movie)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MovieId);




            modelBuilder.Entity<Genre>()
                .HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Comedy"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Drama"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Science Fiction"
                }

                );


            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    GenreId = 5,
                    TicketPrice = 10.00m,
                    AvaillableSeats = 20

                },
                new Movie
                {
                    Id = 2,
                    Title = "The Dark Knight",
                    Director = "Saif Alaa",
                    GenreId = 1,
                    TicketPrice = 12.00m,
                    AvaillableSeats = 20

                },
                new Movie
                {
                    Id = 3,
                    Title = "The Hangover",
                    Director = "Marwawn Hazem",

                    GenreId = 2,
                    TicketPrice = 8.00m,
                    AvaillableSeats = 20

                },
                new Movie
                {
                    Id = 4,
                    Title = "The Shawshank Redemption",
                    Director = "Ahmed Alaa",

                    GenreId = 3,
                    TicketPrice = 9.00m,
                    AvaillableSeats = 20

                },
                new Movie
                {
                    Id = 5,
                    Title = "Get Out",
                    Director = "sayes Alaa",

                    GenreId = 4,
                    TicketPrice = 11.00m,
                    AvaillableSeats = 20

                },
                new Movie
                {
                    Id = 6,
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    GenreId = 5,
                    TicketPrice = 10.00m,
                    AvaillableSeats = 20

                },
                new Movie
                {
                    Id = 7,
                    Title = "The Matrix",
                    Director = "Ali omar",

                    GenreId = 5,
                    TicketPrice = 10.00m,
                    AvaillableSeats = 20

                },
                new Movie
                {
                    Id = 8,
                    Title = "The Godfather",
                    Director = "Hamza Ahmed",

                    GenreId = 3,
                    TicketPrice = 12.00m,
                    AvaillableSeats = 20
                }
            );



            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "John Doe",
                    Email = "john.doe@example.com"
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    Email = "jane.smith@example.com"
                },


                new Customer
                {
                    Id = 3,
                    FullName = "Alice Johnson",
                    Email = "alice.johnson@example.com"
                },
                new Customer
                {
                    Id = 4,
                    FullName = "Bob Brown",
                    Email = "bob.brown@example.com"
                },
                new Customer
                {
                    Id = 5,
                    FullName = "Charlie Davis",
                    Email = "charlie.davis@example.com"
                }
                );



            modelBuilder.Entity<Booking>()
                .HasData(
                new Booking
                {
                    Id = 1,
                    CustomerId = 1,
                    MovieId = 1,
                    NumberOfTickets = 2,
                    Price = 54,
                    BookingDate = new DateTime(2025, 10, 1)
                },
                new Booking
                {
                    Id = 2,
                    CustomerId = 2,
                    MovieId = 2,
                    NumberOfTickets = 3,
                    Price = 36,
                    BookingDate = new DateTime(2013, 10, 1)
                },
                new Booking
                {
                    Id = 3,
                    CustomerId = 3,
                    MovieId = 3,
                    NumberOfTickets = 1,
                    Price = 12,
                    BookingDate = new DateTime(2026, 10, 1)
                },
                new Booking
                {
                    Id = 4,
                    CustomerId = 4,
                    MovieId = 4,
                    NumberOfTickets = 4,
                    Price = 48,
                    BookingDate = new DateTime(2023, 9, 1)
                },
                new Booking
                {
                    Id = 5,
                    CustomerId = 5,
                    MovieId = 5,
                    NumberOfTickets = 2,
                    Price = 22,
                    BookingDate =new DateTime(2023, 10, 11)
                }

            );

        }
    }
}
