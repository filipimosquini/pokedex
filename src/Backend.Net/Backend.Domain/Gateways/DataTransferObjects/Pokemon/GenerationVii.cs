using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GenerationVii
{
    [JsonProperty("icons", NullValueHandling = NullValueHandling.Ignore)]
    public Icons icons { get; set; }

    [JsonProperty("ultra-sun-ultra-moon", NullValueHandling = NullValueHandling.Ignore)]
    public UltraSunUltraMoon ultrasunultramoon { get; set; }
}