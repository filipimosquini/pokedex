using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GenerationIv
{
    [JsonProperty("diamond-pearl", NullValueHandling = NullValueHandling.Ignore)]
    public DiamondPearl diamondpearl { get; set; }

    [JsonProperty("heartgold-soulsilver", NullValueHandling = NullValueHandling.Ignore)]
    public HeartgoldSoulsilver heartgoldsoulsilver { get; set; }

    [JsonProperty("platinum", NullValueHandling = NullValueHandling.Ignore)]
    public Platinum platinum { get; set; }
}