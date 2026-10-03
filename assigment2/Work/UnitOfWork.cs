using assigment2.Data;
using assigment2.Repos.InterFaces;

namespace assigment2.Work
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBook book { get; }

        public ICustomer customer { get; }

        public IMovie movie { get; }            

        public IGenre genre { get; }

        protected readonly AppDbContext appDbContext;
        public UnitOfWork(AppDbContext appDbContext , IBook book , ICustomer customer , IMovie movie , IGenre genre)
        {
            this.appDbContext = appDbContext;
            this.book = book;
            this.customer = customer;
            this.movie = movie;
            this.genre = genre;
        }

        public void Save()
        {
            appDbContext.SaveChanges();
        }
    }
}
