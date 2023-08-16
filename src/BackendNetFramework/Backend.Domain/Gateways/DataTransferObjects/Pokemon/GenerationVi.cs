using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class GenerationVi
{
    [JsonProperty("omegaruby-alphasapphire", NullValueHandling = NullValueHandling.Ignore)]
    public OmegarubyAlphasapphire omegarubyalphasapphire { get; set; }

    [JsonProperty("x-y", NullValueHandling = NullValueHandling.Ignore)]
    public XY xy { get; set; }
}