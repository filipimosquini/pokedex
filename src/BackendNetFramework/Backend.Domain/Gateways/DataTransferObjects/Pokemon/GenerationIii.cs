using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GenerationIii
{
    [JsonProperty("emerald", NullValueHandling = NullValueHandling.Ignore)]
    public Emerald emerald { get; set; }

    [JsonProperty("firered-leafgreen", NullValueHandling = NullValueHandling.Ignore)]
    public FireredLeafgreen fireredleafgreen { get; set; }

    [JsonProperty("ruby-sapphire", NullValueHandling = NullValueHandling.Ignore)]
    public RubySapphire rubysapphire { get; set; }
}