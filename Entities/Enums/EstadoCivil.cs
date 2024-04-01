using System.Text.Json.Serialization;

namespace Api.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoCivil
    {
        Solteiro,
        Casado,
        Separado,
        Divorciado,
        Viuvo
    }
}
