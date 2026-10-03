namespace assigment2.GenaricRepos
{
    public interface IGenriacRepo<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
