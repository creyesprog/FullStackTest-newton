using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackTest_newton.Infrastructure.Database.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
    }
}