using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GenerationI
{
    [JsonProperty("red-blue", NullValueHandling = NullValueHandling.Ignore)]
    public RedBlue redblue { get; set; }

    [JsonProperty("yellow", NullValueHandling = NullValueHandling.Ignore)]
    public Yellow yellow { get; set; }
}