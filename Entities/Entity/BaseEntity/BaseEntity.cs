using System.ComponentModel.DataAnnotations;

namespace Api.Entities.Entity.BaseEntity
{
    public abstract class BaseEntity
    {
        public bool Ativo { get; set; }
        [MaxLength(160)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
