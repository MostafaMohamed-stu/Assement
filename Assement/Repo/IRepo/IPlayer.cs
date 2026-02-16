using Assement.Models;
using Assement.Repo.Genric_Repo;

namespace Assement.Repo.IRepo
{
    public interface IPlayer :IGenricRepo<Player>
    {
        Task<List<Player>> GetPlayer();
    }
}
