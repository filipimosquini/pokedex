using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Move
{
    [JsonProperty("move", NullValueHandling = NullValueHandling.Ignore)]
    public Move move { get; set; }

    [JsonProperty("version_group_details", NullValueHandling = NullValueHandling.Ignore)]
    public List<VersionGroupDetail> version_group_details { get; set; }
}