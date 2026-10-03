using assigment2.GenaricRepos;
using assigment2.Models;

namespace assigment2.Repos.InterFaces
{
    public interface IGenre : IGenriacRepo<Genre>
    {
        List<Genre> GetGenresWithMovies();
    }
}
