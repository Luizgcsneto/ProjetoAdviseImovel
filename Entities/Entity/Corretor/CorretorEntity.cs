using System.ComponentModel.DataAnnotations;

namespace Api.Entities.Entity.Corretor
{
    public class CorretorEntity : BaseEntity.BaseEntity
    {
        [Key]
        public int CorretorId { get; set; }
    }
}
