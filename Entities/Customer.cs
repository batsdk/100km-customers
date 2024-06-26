using System.Text.Json.Serialization;

namespace DevUpLink.Entities
{
    public class Customer
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

    }
}