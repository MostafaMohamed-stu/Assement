using Assement.Models;
using Assement.Repo.Genric_Repo;

namespace Assement.Repo.IRepo
{
    public interface ICompetion :IGenricRepo<Competion>
    {
        Task<List<Competion>> GetCompetion();
    }
}
