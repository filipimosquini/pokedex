using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class PastType
{
    [JsonProperty("generation", NullValueHandling = NullValueHandling.Ignore)]
    public Generation generation { get; set; }

    [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
    public List<Type> types { get; set; }
}