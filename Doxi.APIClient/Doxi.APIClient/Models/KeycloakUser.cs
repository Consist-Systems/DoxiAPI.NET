using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Doxi.APIClient.Models
{
    internal class KeycloakUser : User
    {
        [JsonPropertyName("attributes")]
        public Dictionary<string, IEnumerable<string>> Attributes { get; set; }

        public long CreatedTimestamp { get; set; }
    }
}
