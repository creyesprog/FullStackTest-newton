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
using FullStackTest_newton.Infrastructure.Models;
using FullStackTest_newton.Infrastructure.Database.Models;

namespace FullStackTest_newton.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : _BaseController
    {
        protected readonly IGameService gameService;

        public GamesController() : base()
        {
            ErrorModel = new ErrorModel();
            GameDirectoryContext gameDb = new GameDirectoryContext();
            GameRepository gameRepository = new GameRepository(gameDb);
            gameService = new GameService(gameRepository, ErrorModel);
        }

        public GamesController(IGameService gameService, IErrorModel errorModel) : base()
        {
            this.gameService = gameService;
            ErrorModel = errorModel;
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

            return Ok(responseDTO);
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

            return Ok(responseDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]UpdateGameRequestDTO dto)
        {
            ResponseDTO responseDTO = new ResponseDTO(ErrorModel);

            if (ModelState.IsValid)
            {
                // Massage data
                dto.Title = dto.Title.Trim();
                dto.Developer = dto.Developer.Trim();
                dto.Genre = dto.Genre.Trim();
                dto.Description = dto.Description.Trim();

                await gameService.UpdateGame(dto);

                // If no errors accumulated from controller or service then continue
                if (ErrorModel.Errors.Count == 0)
                {
                    return Ok(responseDTO);
                }
            }

            // TODO: Distinguish between different error types (500, etc) and send back error obj (response DTO)

            return BadRequest();
        }
    }
}
