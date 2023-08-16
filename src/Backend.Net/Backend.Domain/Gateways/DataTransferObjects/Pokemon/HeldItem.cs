using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class HeldItem
{
    [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
    public Item item { get; set; }

    [JsonProperty("version_details", NullValueHandling = NullValueHandling.Ignore)]
    public List<VersionDetail> version_details { get; set; }
}