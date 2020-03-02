using Newtonsoft.Json;

namespace htapnurExercise.Models
{
    public class Photo
    {
        [JsonProperty("albumId")]
        public int AlbumId { get; set; }
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
    }
}
