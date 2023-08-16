using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Type
{
    [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
    public int slot { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public Type type { get; set; }
}