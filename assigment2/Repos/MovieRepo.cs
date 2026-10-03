using assigment2.Models;
using assigment2.Repos.InterFaces;
using assigment2.GenaricRepos;
using assigment2.Data;
using Microsoft.EntityFrameworkCore;
namespace assigment2.Repos
{
    public class MovieRepo : GenriacRepo<Movie>, IMovie
    {


        public MovieRepo(AppDbContext appDb) : base(appDb)
        {
            
        }
        public List<Movie> GetAvailable()
        {
            return appDbContext.Movies.Where(m => m.AvaillableSeats > 0).ToList();
        }

        public decimal GetAveragePrice()
        {
            return appDbContext.Movies.Average(p => p.TicketPrice);
        }

        public int GetCount()
        {
            return appDbContext.Movies.Count();
        }

        public Movie GetLatest()
        {
           var latestMovie = appDbContext.Movies.OrderByDescending(m => m.ReleaseYear).FirstOrDefault();
            return latestMovie;
        }

        public Movie GetMostBooked()
        {
            var mostBookedMovie = appDbContext.Movies
                .OrderByDescending(m => m.Bookings.Count)
                .FirstOrDefault();

            return mostBookedMovie;
        }

        public List<Movie> GetMoviesWithGenre()
        {
            return appDbContext.Movies.Include(m => m.Genre).ToList();
        }

        public List<Movie> GetPaged(int pageNumber, int pageSize)
        {
            return appDbContext.Movies
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public List<Movie> GetPriceBetween(decimal min, decimal max)
        {
            return appDbContext.Movies.Where(m => m.TicketPrice >= min && m.TicketPrice <= max).ToList();
        }

        public List<Movie> GetRatingGreaterThan(decimal rating)
        {
            return appDbContext.Movies.Where(m => m.Rating > rating).ToList();
        }

        public Movie GetTopRated()
        {
            return appDbContext.Movies.OrderByDescending(m => m.Rating).FirstOrDefault();
        }

        public List<Movie> Search(string title)
        {
            return appDbContext.Movies.Where(m => m.Title.Contains(title)).ToList();
        }
    }
}
