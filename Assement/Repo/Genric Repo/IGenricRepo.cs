namespace Assement.Repo.Genric_Repo
{
    public interface IGenricRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Post(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
