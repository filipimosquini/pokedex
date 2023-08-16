using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Other
{
    [JsonProperty("dream_world", NullValueHandling = NullValueHandling.Ignore)]
    public DreamWorld dream_world { get; set; }

    [JsonProperty("home", NullValueHandling = NullValueHandling.Ignore)]
    public Home home { get; set; }

    [JsonProperty("official-artwork", NullValueHandling = NullValueHandling.Ignore)]
    public OfficialArtwork officialartwork { get; set; }
}