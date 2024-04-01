using Api.Entities.Entity.Corretor;
using Api.Entities.Entity.Imovel;
using Api.Entities.Entity.ServiceResponse;

namespace Api.Domain.Interfaces.Imovel
{
    public interface IimovelInterface
    {
        Task<ServiceResponse<List<ImovelEntity>>> GetAll();
        Task<ServiceResponse<List<ImovelEntity>>> Create(ImovelEntity entity);
        Task<ServiceResponse<ImovelEntity>> GetEntityById(int id);
        Task<ServiceResponse<List<ImovelEntity>>> Update(ImovelEntity entityEdit);

        Task<ServiceResponse<List<ImovelEntity>>> Delete(int id);
        Task<ServiceResponse<List<ImovelEntity>>> Inativa(int id);
    }
}
