using Api.Entities.Entity.Imovel;
using Api.Entities.Entity.Inquilinos;
using Api.Entities.Entity.ServiceResponse;

namespace Api.Domain.Interfaces.Inquilino
{
    public interface InquilinoInterface
    {
        Task<ServiceResponse<List<InquilinoEntity>>> GetAll();
        Task<ServiceResponse<List<InquilinoEntity>>> Create(InquilinoEntity entity);
        Task<ServiceResponse<InquilinoEntity>> GetEntityById(int id);
        Task<ServiceResponse<List<InquilinoEntity>>> Update(InquilinoEntity entityEdit);

        Task<ServiceResponse<List<InquilinoEntity>>> Delete(int id);
        Task<ServiceResponse<List<InquilinoEntity>>> Inativa(int id);
    }
}
