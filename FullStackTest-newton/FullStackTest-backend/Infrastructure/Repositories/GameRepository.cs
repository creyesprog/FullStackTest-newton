using FullStackTest_newton.Infrastructure.Database;
using FullStackTest_newton.Infrastructure.Database.Models;
using FullStackTest_newton.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FullStackTest_newton.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDirectoryContext db;

        public GameRepository(GameDirectoryContext db)
        {
            this.db = db;
        }

        public async Task<IList<Game>> GetGames()
        {
            return await db.Games.ToListAsync();
        }

        public async Task<Game> GetGame(int gameId)
        {
            return await db.Games.FirstOrDefaultAsync(x => x.GameID == gameId);
        }

        public void UpdateGame(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
            db.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            bool success;
            try
            {
                success = await db.SaveChangesAsync() > 0;
            }
            catch (DbException)
            {
                throw;
            }
            return success;
        }
    }
}