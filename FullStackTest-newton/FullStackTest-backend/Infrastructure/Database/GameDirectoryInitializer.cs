using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FullStackTest_newton.Infrastructure.Database.Models;

namespace FullStackTest_newton.Infrastructure.Database
{
    public class GameDirectoryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GameDirectoryContext>
    {
        protected override void Seed(GameDirectoryContext context)
        {
            var games = new List<Game>
            {
                new Game() { Title = "Legend Of Zelda: Ocarina of Time", Rating = 5, Developer = "Nintendo", Genre = "Action-adventure",  Description = "The Legend of Zelda: Ocarina of Time is an action-adventure game developed and published by Nintendo for the Nintendo 64. It was released in Japan and North America in November 1998, and in PAL regions the following month. Ocarina of Time is the fifth game in The Legend of Zelda series, and the first with 3D graphics." },
                new Game() { Title = "Conker's Bad Fur Day", Rating = 5, Developer = "Rare", Genre = "Platform",  Description = "Conker's Bad Fur Day is a platform game developed by Rare and released for the Nintendo 64 console in 2001. As part of the Conker series, the game follows the story of Conker the Squirrel, a greedy, heavy-drinking red squirrel who must return home to his girlfriend." },
                new Game() { Title = "GoldenEye 007", Rating = 5, Developer = "Rare", Genre = "Shooter",  Description = "GoldenEye 007 is a 1997 first-person shooter developed by Rare and published by Nintendo for the Nintendo 64." },
                new Game() { Title = "Mario Kart 64", Rating = 4, Developer = "Nintendo", Genre = "Racing",  Description = "Mario Kart 64 is a kart racing video game developed and published by Nintendo for the Nintendo 64. It is the successor to Super Mario Kart for the Super Nintendo Entertainment System, and the second game in the Mario Kart series. It was released in Japan on December 14, 1996, and in North America and Europe in 1997." },
                new Game() { Title = "Super Mario 64", Rating = 5, Developer = "Nintendo", Genre = "Platform",  Description = "Super Mario 64 is a 1996 platform game for the Nintendo 64 and the first in the Super Mario series to feature 3D gameplay. As Mario, the player explores Princess Peach's castle and must rescue her from Bowser." },
                new Game() { Title = "Pokémon Stadium 2", Rating = 5, Developer = "Nintendo", Genre = "Strategy",  Description = "Pokémon Stadium 2 is a strategy video game developed by Nintendo EAD and published by Nintendo for the Nintendo 64. It features all 251 Pokémon from the first and second generations of the franchise. It was released in Japan on December 14, 2000, in North America on March 26, 2001, and in Europe on October 10, 2001." },
                new Game() { Title = "Halo: Combat Evolved", Rating = 5, Developer = "Bungie", Genre = "Shooter",  Description = "Halo: Combat Evolved is a first-person shooter video game developed by Bungie and published by Microsoft Game Studios. It was released as a launch title for Microsoft's Xbox video game console on November 15, 2001. Microsoft released versions of the game for Windows and Mac OS X in 2003." },
                new Game() { Title = "Super Smash Bros.", Rating = 5, Developer = "Nintendo", Genre = "Fighting",  Description = "Super Smash Bros. is a crossover fighting video game developed by HAL Laboratory and published by Nintendo for the Nintendo 64. It was first released in Japan on January 21, 1999, in North America on April 26, 1999, and in Europe on November 19, 1999." },
                new Game() { Title = "God of War", Rating = 5, Developer = "SIE Santa Monica Studio", Genre = "Action-adventure",  Description = "God of War is an action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment. Released on April 20, 2018, for the PlayStation 4, it is the eighth installment in the God of War series, the eighth chronologically, and the sequel to 2010's God of War III." },
            };

            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }
}