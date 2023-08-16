using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class DiamondPearl
{
    [JsonProperty("back_default", NullValueHandling = NullValueHandling.Ignore)]
    public string back_default { get; set; }

    [JsonProperty("back_female", NullValueHandling = NullValueHandling.Ignore)]
    public object back_female { get; set; }

    [JsonProperty("back_shiny", NullValueHandling = NullValueHandling.Ignore)]
    public string back_shiny { get; set; }

    [JsonProperty("back_shiny_female", NullValueHandling = NullValueHandling.Ignore)]
    public object back_shiny_female { get; set; }

    [JsonProperty("front_default", NullValueHandling = NullValueHandling.Ignore)]
    public string front_default { get; set; }

    [JsonProperty("front_female", NullValueHandling = NullValueHandling.Ignore)]
    public object front_female { get; set; }

    [JsonProperty("front_shiny", NullValueHandling = NullValueHandling.Ignore)]
    public string front_shiny { get; set; }

    [JsonProperty("front_shiny_female", NullValueHandling = NullValueHandling.Ignore)]
    public object front_shiny_female { get; set; }
}