using Api.Entities.Entity.Imovel;
using Api.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities.Entity.Proprietario
{
    public class ProprietarioEntity : BaseEntity.BaseEntity
    {
        [Key]
        public int ProprietarioId { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

    }
}
