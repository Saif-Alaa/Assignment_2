using assigment2.GenaricRepos;
using assigment2.Models;

namespace assigment2.Repos.InterFaces
{
    public interface IMovie : IGenriacRepo<Movie>
    {
        List<Movie> Search(string title);
        List<Movie> GetRatingGreaterThan(decimal rating);
        List<Movie> GetPriceBetween(decimal min, decimal max);
        List<Movie> GetAvailable();
        Movie GetTopRated();
        Movie GetLatest();
        Movie GetMostBooked();
        int GetCount();
        decimal GetAveragePrice();
        List<Movie> GetMoviesWithGenre();
        List<Movie> GetPaged(int pageNumber, int pageSize);
    }
}
