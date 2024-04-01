using System.Text.Json.Serialization;

namespace Api.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoImovel
    {
        Comercial,
        Residencial
    }
}
