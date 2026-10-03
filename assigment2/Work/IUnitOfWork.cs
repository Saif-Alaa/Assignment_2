using assigment2.Models;
using assigment2.Repos.InterFaces;

namespace assigment2.Work
{
    public interface IUnitOfWork
    {
        IBook book { get; }
        ICustomer customer { get; }
        IMovie movie { get; }

        IGenre genre { get; }


        void Save();
    }
}
