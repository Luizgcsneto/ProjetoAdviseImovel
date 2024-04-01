using System.ComponentModel.DataAnnotations;

namespace Api.Entities.Entity.Inquilinos
{
    public class InquilinoEntity : BaseEntity.BaseEntity
    {
        [Key]
        public int InquilinoId { get; set; }
    }
}
