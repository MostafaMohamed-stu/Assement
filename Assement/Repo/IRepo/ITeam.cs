using Assement.Models;
using Assement.Repo.Genric_Repo;

namespace Assement.Repo.IRepo
{
    public interface ITeam :IGenricRepo<Team>
    {
        Task<List<Team>> GetTeams();
    }
}
