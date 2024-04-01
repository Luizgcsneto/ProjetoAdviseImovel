using Api.Entities.Entity.Proprietario;
using Api.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities.Entity.Imovel
{
    public class ImovelEntity : BaseEntity.BaseEntity
    {
        [Key]
        public int ImovelId { get; set; }
        public TipoImovel TipoImovel { get; set; }

    }
}
