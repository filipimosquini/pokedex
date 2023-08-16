using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class VersionDetail
{
    [JsonProperty("rarity", NullValueHandling = NullValueHandling.Ignore)]
    public int rarity { get; set; }

    [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
    public Version version { get; set; }
}