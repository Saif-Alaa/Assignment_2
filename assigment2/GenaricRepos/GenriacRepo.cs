using assigment2.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace assigment2.GenaricRepos
{
    public class GenriacRepo<T> : IGenriacRepo<T> where T : class
    {

        protected readonly AppDbContext appDbContext;

        public GenriacRepo(AppDbContext appDb)
        {
            appDbContext = appDb;
        }
        public void Create(T entity)
        {
            appDbContext.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = appDbContext.Set<T>().Find(id);
            if (entity != null)
            {
                appDbContext.Set<T>().Remove(entity);
            }
        }

        public List<T> GetAll()
        {
            return appDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return appDbContext.Set<T>().Find(id);

        }

        public void Update(T entity)
        {
            appDbContext.Set<T>().Update(entity);
        }
        }
    }

