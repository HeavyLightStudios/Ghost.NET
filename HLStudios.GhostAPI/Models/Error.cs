using System.Text.Json.Serialization;

namespace HLStudios.GhostAPI.Models
{
    public class Error
    {
        [JsonPropertyName("message")] 
        public string Message { get; set; }
        [JsonPropertyName("errorType")] 
        public string ErrorType { get; set; }
    }
}