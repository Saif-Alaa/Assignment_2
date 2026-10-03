using assigment2.Data;
using assigment2.GenaricRepos;
using assigment2.Models;
using assigment2.Repos.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace assigment2.Repos
{
    public class GenreRepo : GenriacRepo<Genre> , IGenre
    {
        public GenreRepo(AppDbContext context) : base(context)
        {
            
        }

        public List<Genre> GetGenresWithMovies()
        {
            return appDbContext.Genres
                .Include(g => g.Movies)
                .ToList();
        }
    }
}
