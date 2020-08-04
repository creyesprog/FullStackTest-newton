using FullStackTest_newton.Infrastructure.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackTest_newton.Infrastructure.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetGame(int gameId);
        Task<IList<Game>> GetGames();
        Task<bool> SaveChangesAsync();
        void UpdateGame(Game game);
    }
}