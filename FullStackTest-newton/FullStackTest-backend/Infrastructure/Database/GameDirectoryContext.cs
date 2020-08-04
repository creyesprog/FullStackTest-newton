using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FullStackTest_newton.Infrastructure.Database.Models;

namespace FullStackTest_newton.Infrastructure.Database
{
    public class GameDirectoryContext : DbContext
    {
        public GameDirectoryContext():base("GameDirectoryContext")
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}