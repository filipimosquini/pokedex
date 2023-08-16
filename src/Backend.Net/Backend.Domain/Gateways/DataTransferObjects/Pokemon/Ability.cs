using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Ability
{
    [JsonProperty("is_hidden", NullValueHandling = NullValueHandling.Ignore)]
    public bool is_hidden { get; set; }

    [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
    public int slot { get; set; }

    [JsonProperty("ability", NullValueHandling = NullValueHandling.Ignore)]
    public Ability ability { get; set; }
}