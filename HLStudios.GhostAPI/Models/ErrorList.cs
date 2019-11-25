using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HLStudios.GhostAPI.Models
{
    public class ErrorList
    {
        [JsonPropertyName("errors")] 
        public IList<Error> Error { get; set; }
    }
}