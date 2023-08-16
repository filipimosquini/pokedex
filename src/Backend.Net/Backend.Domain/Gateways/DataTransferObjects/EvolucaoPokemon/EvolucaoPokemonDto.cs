using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.EvolucaoPokemon;

public class EvolucaoPokemonDto
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public int id { get; set; }

    [JsonProperty("baby_trigger_item", NullValueHandling = NullValueHandling.Ignore)]
    public object baby_trigger_item { get; set; }

    [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
    public Chain chain { get; set; }
}