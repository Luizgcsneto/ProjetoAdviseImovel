using Api.Entities.Entity.Inquilinos;
using Api.Entities.Entity.Proprietario;
using Api.Entities.Entity.ServiceResponse;

namespace Api.Domain.Interfaces.Proprietario
{
    public interface IProprietarioInterface
    {
        Task<ServiceResponse<List<ProprietarioEntity>>> GetAll();
        Task<ServiceResponse<List<ProprietarioEntity>>> Create(ProprietarioEntity entity);
        Task<ServiceResponse<ProprietarioEntity>> GetEntityById(int id);
        Task<ServiceResponse<List<ProprietarioEntity>>> Update(ProprietarioEntity entityEdit);

        Task<ServiceResponse<List<ProprietarioEntity>>> Delete(int id);
        Task<ServiceResponse<List<ProprietarioEntity>>> Inativa(int id);
    }
}
