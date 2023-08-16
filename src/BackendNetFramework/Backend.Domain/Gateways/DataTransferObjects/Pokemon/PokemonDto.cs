using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend.Domain.Gateways.DataTransferObjects.Pokemon;

public class PokemonDto
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public int id { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string name { get; set; }

    [JsonProperty("base_experience", NullValueHandling = NullValueHandling.Ignore)]
    public int base_experience { get; set; }

    [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
    public int height { get; set; }

    [JsonProperty("is_default", NullValueHandling = NullValueHandling.Ignore)]
    public bool is_default { get; set; }

    [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
    public int order { get; set; }

    [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
    public int weight { get; set; }

    [JsonProperty("abilities", NullValueHandling = NullValueHandling.Ignore)]
    public List<Ability> abilities { get; set; }

    [JsonProperty("forms", NullValueHandling = NullValueHandling.Ignore)]
    public List<Form> forms { get; set; }

    [JsonProperty("game_indices", NullValueHandling = NullValueHandling.Ignore)]
    public List<GameIndex> game_indices { get; set; }

    [JsonProperty("held_items", NullValueHandling = NullValueHandling.Ignore)]
    public List<HeldItem> held_items { get; set; }

    [JsonProperty("location_area_encounters", NullValueHandling = NullValueHandling.Ignore)]
    public string location_area_encounters { get; set; }

    [JsonProperty("moves", NullValueHandling = NullValueHandling.Ignore)]
    public List<Move> moves { get; set; }

    [JsonProperty("species", NullValueHandling = NullValueHandling.Ignore)]
    public Species species { get; set; }

    [JsonProperty("sprites", NullValueHandling = NullValueHandling.Ignore)]
    public Sprites sprites { get; set; }

    [JsonProperty("stats", NullValueHandling = NullValueHandling.Ignore)]
    public List<Stat> stats { get; set; }

    [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
    public List<Type> types { get; set; }

    [JsonProperty("past_types", NullValueHandling = NullValueHandling.Ignore)]
    public List<PastType> past_types { get; set; }
}