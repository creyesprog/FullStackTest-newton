using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackTest_newton.Infrastructure.Models.DTOs
{
    public class GameResponseDTO
    {
        [JsonProperty("gameId")]
        public int GameId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("rating")]
        public int Rating { get; set; }
        [JsonProperty("developer")]
        public string Developer { get; set; }
        [JsonProperty("genre")]
        public string Genre { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}