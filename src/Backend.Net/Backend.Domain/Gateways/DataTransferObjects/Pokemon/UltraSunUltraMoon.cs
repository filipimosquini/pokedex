using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class UltraSunUltraMoon
{
    [JsonProperty("front_default", NullValueHandling = NullValueHandling.Ignore)]
    public string front_default { get; set; }

    [JsonProperty("front_female", NullValueHandling = NullValueHandling.Ignore)]
    public object front_female { get; set; }

    [JsonProperty("front_shiny", NullValueHandling = NullValueHandling.Ignore)]
    public string front_shiny { get; set; }

    [JsonProperty("front_shiny_female", NullValueHandling = NullValueHandling.Ignore)]
    public object front_shiny_female { get; set; }
}