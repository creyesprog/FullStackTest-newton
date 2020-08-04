using FullStackTest_newton.Infrastructure.Database.Models;
using FullStackTest_newton.Infrastructure.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackTest_newton.Infrastructure.Services.Interfaces
{
    public interface IGameService
    {
        Task<Game> GetGame(int gameId);
        Task<IList<Game>> GetGames();
        Task<bool> UpdateGame(UpdateGameRequestDTO dto);
    }
}