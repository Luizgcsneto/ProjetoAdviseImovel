using Api.Entities.Entity.Corretor;
using Api.Entities.Entity.ServiceResponse;

namespace Api.Domain.Interfaces.Corretor
{
    public interface ICorretorInterface
    {
        Task<ServiceResponse<List<CorretorEntity>>> GetAll();
        Task<ServiceResponse<List<CorretorEntity>>> Create(CorretorEntity entity);
        Task<ServiceResponse<CorretorEntity>> GetEntityById(int id);
        Task<ServiceResponse<List<CorretorEntity>>> Update(CorretorEntity entityEdit);

        Task<ServiceResponse<List<CorretorEntity>>> Delete(int id);
        Task<ServiceResponse<List<CorretorEntity>>> Inativa(int id);
    }
}
