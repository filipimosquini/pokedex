using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class RedBlue
{
    [JsonProperty("back_default", NullValueHandling = NullValueHandling.Ignore)]
    public string back_default { get; set; }

    [JsonProperty("back_gray", NullValueHandling = NullValueHandling.Ignore)]
    public string back_gray { get; set; }

    [JsonProperty("front_default", NullValueHandling = NullValueHandling.Ignore)]
    public string front_default { get; set; }

    [JsonProperty("front_gray", NullValueHandling = NullValueHandling.Ignore)]
    public string front_gray { get; set; }
}