using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Stat
{
    [JsonProperty("base_stat", NullValueHandling = NullValueHandling.Ignore)]
    public int base_stat { get; set; }

    [JsonProperty("effort", NullValueHandling = NullValueHandling.Ignore)]
    public int effort { get; set; }

    [JsonProperty("stat", NullValueHandling = NullValueHandling.Ignore)]
    public Stat stat { get; set; }
}