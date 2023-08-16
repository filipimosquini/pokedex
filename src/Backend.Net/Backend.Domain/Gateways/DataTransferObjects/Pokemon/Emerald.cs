using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Emerald
{
    [JsonProperty("front_default", NullValueHandling = NullValueHandling.Ignore)]
    public string front_default { get; set; }

    [JsonProperty("front_shiny", NullValueHandling = NullValueHandling.Ignore)]
    public string front_shiny { get; set; }
}