using Assement.Models;
using Assement.Repo.Genric_Repo;

namespace Assement.Repo.IRepo
{
    public interface ICoach :IGenricRepo<Team>
    {
        Task<List<Team>> GetCoach();
        Task<Team> GetCoach(int id);
    }
}
