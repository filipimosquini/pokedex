using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GenerationV
{
    [JsonProperty("black-white", NullValueHandling = NullValueHandling.Ignore)]
    public BlackWhite blackwhite { get; set; }
}