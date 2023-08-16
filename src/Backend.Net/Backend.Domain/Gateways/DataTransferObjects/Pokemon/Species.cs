﻿using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class Species
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string name { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string url { get; set; }
}