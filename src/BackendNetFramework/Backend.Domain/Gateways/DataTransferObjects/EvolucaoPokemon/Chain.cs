using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.EvolucaoPokemon;

public class Chain
{
    [JsonProperty("is_baby", NullValueHandling = NullValueHandling.Ignore)]
    public bool is_baby { get; set; }

    [JsonProperty("species", NullValueHandling = NullValueHandling.Ignore)]
    public Species species { get; set; }

    [JsonProperty("evolves_to", NullValueHandling = NullValueHandling.Ignore)]
    public List<EvolvesTo> evolves_to { get; set; }
}