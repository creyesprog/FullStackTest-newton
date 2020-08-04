using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullStackTest_newton.Infrastructure.Models.DTOs
{
    public class UpdateGameRequestDTO
    {
        [Required]
        [JsonProperty("gameId")]
        public int GameId { get; set; }
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        [Required]
        [JsonProperty("rating")]
        public int Rating { get; set; }
        [Required]
        [JsonProperty("developer")]
        public string Developer { get; set; }
        [Required]
        [JsonProperty("genre")]
        public string Genre { get; set; }
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}