using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GameIndex
{
    [JsonProperty("game_index", NullValueHandling = NullValueHandling.Ignore)]
    public int game_index { get; set; }

    [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
    public Version version { get; set; }
}