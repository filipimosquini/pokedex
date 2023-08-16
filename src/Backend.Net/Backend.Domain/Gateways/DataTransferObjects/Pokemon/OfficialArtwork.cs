using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class OfficialArtwork
{
    [JsonProperty("front_default", NullValueHandling = NullValueHandling.Ignore)]
    public string front_default { get; set; }
}