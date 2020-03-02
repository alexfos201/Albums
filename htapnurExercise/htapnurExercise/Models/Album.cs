using Newtonsoft.Json;
using System.Collections.Generic;

namespace htapnurExercise.Models
{
    public class Album
    {
        public Album()
        {
            this.Photos = new List<Photo>();
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
