using FullStackTest_newton.Infrastructure.Database.Models;
using FullStackTest_newton.Infrastructure.Models;
using FullStackTest_newton.Infrastructure.Models.DTOs;
using FullStackTest_newton.Infrastructure.Repositories;
using FullStackTest_newton.Infrastructure.Repositories.Interfaces;
using FullStackTest_newton.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Web;

namespace FullStackTest_newton.Infrastructure.Services
{
    public class GameService : _BaseService, IGameService
    {
        private readonly IGameRepository gameRepository;

        public GameService(IGameRepository gameRepository, IErrorModel errorModel) : base(errorModel)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<IList<Game>> GetGames()
        {
            return await gameRepository.GetGames();
        }

        public async Task<Game> GetGame(int gameId)
        {
            return await gameRepository.GetGame(gameId);
        }


        public async Task<bool> UpdateGame(UpdateGameRequestDTO dto)
        {
            bool success = false;

            try
            {
                Game game = new Game()
                {
                    GameID = dto.GameId,
                    Title = dto.Title,
                    Rating = dto.Rating,
                    Developer = dto.Developer,
                    Description = dto.Description,
                    Genre = dto.Genre
                };

                gameRepository.UpdateGame(game);
                await gameRepository.SaveChangesAsync();

                success = true;
            }
            catch (DbException ex)
            {
                AddModelError("Error grabbing data from database");
                // Log errors
            }
            return success;
        }
    }
}