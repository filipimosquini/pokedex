using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GenerationViii
{
    [JsonProperty("icons", NullValueHandling = NullValueHandling.Ignore)]
    public Icons icons { get; set; }
}