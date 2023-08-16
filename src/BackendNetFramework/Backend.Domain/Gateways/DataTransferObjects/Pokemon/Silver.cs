using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Silver
{
    [JsonProperty("back_default", NullValueHandling = NullValueHandling.Ignore)]
    public string back_default { get; set; }

    [JsonProperty("back_shiny", NullValueHandling = NullValueHandling.Ignore)]
    public string back_shiny { get; set; }

    [JsonProperty("front_default", NullValueHandling = NullValueHandling.Ignore)]
    public string front_default { get; set; }

    [JsonProperty("front_shiny", NullValueHandling = NullValueHandling.Ignore)]
    public string front_shiny { get; set; }
}