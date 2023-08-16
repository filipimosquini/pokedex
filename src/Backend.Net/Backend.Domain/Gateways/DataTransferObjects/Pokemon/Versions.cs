using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Versions
{
    [JsonProperty("generation-i", NullValueHandling = NullValueHandling.Ignore)]
    public GenerationI generationi { get; set; }

    [JsonProperty("generation-ii", NullValueHandling = NullValueHandling.Ignore)]
    public GenerationIi generationii { get; set; }

    [JsonProperty("generation-iii", NullValueHandling = NullValueHandling.Ignore)]
    public GenerationIii generationiii { get; set; }

    [JsonProperty("generation-iv", NullValueHandling = NullValueHandling.Ignore)]
    public GenerationIv generationiv { get; set; }

    [JsonProperty("generation-v", NullValueHandling = NullValueHandling.Ignore)]
    public GenerationV generationv { get; set; }

    [JsonProperty("generation-vi", NullValueHandling = NullValueHandling.Ignore)]
    public GenerationVi generationvi { get; set; }

    [JsonProperty("generation-vii", NullValueHandling = NullValueHandling.Ignore)]
    public GenerationVii generationvii { get; set; }

    [JsonProperty("generation-viii", NullValueHandling = NullValueHandling.Ignore)]
    public GenerationViii generationviii { get; set; }
}