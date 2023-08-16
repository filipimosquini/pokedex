using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class VersionGroupDetail
{
    [JsonProperty("level_learned_at", NullValueHandling = NullValueHandling.Ignore)]
    public int level_learned_at { get; set; }

    [JsonProperty("version_group", NullValueHandling = NullValueHandling.Ignore)]
    public VersionGroup version_group { get; set; }

    [JsonProperty("move_learn_method", NullValueHandling = NullValueHandling.Ignore)]
    public MoveLearnMethod move_learn_method { get; set; }
}