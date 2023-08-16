using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GenerationIi
{
    [JsonProperty("crystal", NullValueHandling = NullValueHandling.Ignore)]
    public Crystal crystal { get; set; }

    [JsonProperty("gold", NullValueHandling = NullValueHandling.Ignore)]
    public Gold gold { get; set; }

    [JsonProperty("silver", NullValueHandling = NullValueHandling.Ignore)]
    public Silver silver { get; set; }
}