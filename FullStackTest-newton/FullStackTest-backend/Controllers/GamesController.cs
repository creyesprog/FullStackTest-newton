using FullStackTest_newton.Infrastructure.Database;
using FullStackTest_newton.Infrastructure.Models.DTOs;
using FullStackTest_newton.Infrastructure.Repositories;
using FullStackTest_newton.Infrastructure.Services;
using FullStackTest_newton.Infrastructure.Services.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace FullStackTest_newton.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        protected readonly IGameService gameService;

        public GamesController()
        {
            GameDirectoryContext gameDb = new GameDirectoryContext();
            GameRepository gameRepository = new GameRepository(gameDb);
            gameService = new GameService(gameRepository);
        }

        /// <summary>
        /// Get all submissions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            // Prepare DTO
            List<GameListResponseDTO> responseDTO = await gameService.GetGames().ContinueWith(
                x => x.Result.Select(z => new GameListResponseDTO()
                {
                    GameId = z.GameID,
                    Title = z.Title,
                    Rating = z.Rating,
                    Developer = z.Developer,
                    Genre = z.Genre,
                    Description = z.Description
                }).ToList());

            return Json(responseDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            // Prepare DTO
            GameResponseDTO responseDTO = await gameService.GetGame(id).ContinueWith(
                z => new GameResponseDTO()
                {
                    GameId = z.Result.GameID,
                    Title = z.Result.Title,
                    Rating = z.Result.Rating,
                    Developer = z.Result.Developer,
                    Genre = z.Result.Genre,
                    Description = z.Result.Description
                });

            return Json(responseDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]UpdateGameRequestDTO dto)
        {
            if (ModelState.IsValid)
            {
                // Massage data
                dto.Title = dto.Title.Trim();
                dto.Developer = dto.Developer.Trim();
                dto.Genre = dto.Genre.Trim();
                dto.Description = dto.Description.Trim();

                await gameService.UpdateGame(dto);

                return Ok();
            }
            return BadRequest();
        }
    }
}
