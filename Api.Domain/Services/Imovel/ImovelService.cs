using Api.Domain.Interfaces.Imovel;
using Api.Entities.Entity.Corretor;
using Api.Entities.Entity.Imovel;
using Api.Entities.Entity.ServiceResponse;
using Api.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Services.Imovel
{
    public class ImovelService : IimovelInterface
    {
        private readonly AppDbContext _context;
        public ImovelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ImovelEntity>>> GetAll()
        {
            var listaEntities = new ServiceResponse<List<ImovelEntity>>();
            listaEntities.Mensagem = "Consulta realizada com sucesso";

            try
            {
                listaEntities.Dados = _context.Imoveis.ToList();

                if (listaEntities.Dados.Count == 0)
                {
                    listaEntities.Mensagem = "Não foram encontrados resultados";
                    listaEntities.Sucesso = false;
                }
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<ImovelEntity>> GetEntityById(int id)
        {
            var entity = new ServiceResponse<ImovelEntity>();

            try
            {
                var entityBase = _context.Imoveis.FirstOrDefault(x => x.ImovelId == id);

                if (entityBase == null)
                {
                    entity.Dados = null;
                    entity.Mensagem = "Não foi encontrado resultado";
                    entity.Sucesso = false;
                    return entity;
                }

                entity.Dados = entityBase;
                entity.Mensagem = "Registro selecionado com sucesso";
            }
            catch (Exception ex)
            {
                entity.Mensagem = ex.Message;
                entity.Sucesso = false;
            }

            return entity;
        }

        public async Task<ServiceResponse<List<ImovelEntity>>> Create(ImovelEntity entity)
        {
            var listaEntities = new ServiceResponse<List<ImovelEntity>>();

            try
            {

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Informar dados";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }

                _context.Imoveis.Add(entity);
                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Imoveis.ToList();
                listaEntities.Mensagem = "Registro cadastrado com sucesso";

            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<ImovelEntity>>> Delete(int id)
        {
            var listaEntities = new ServiceResponse<List<ImovelEntity>>();

            try
            {
                var entity = _context.Imoveis.FirstOrDefault(x => x.ImovelId == id);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }


                _context.Imoveis.Remove(entity);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Imoveis.ToList();
                listaEntities.Mensagem = "Registro deletado com sucesso";

            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<ImovelEntity>>> Inativa(int id)
        {
            var listaEntities = new ServiceResponse<List<ImovelEntity>>();

            try
            {
                var entity = _context.Imoveis.FirstOrDefault(x => x.ImovelId == id);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }

                entity.Ativo = false;
                entity.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Imoveis.Update(entity);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Imoveis.ToList();
                listaEntities.Mensagem = "Registro inativado com sucesso";
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<ImovelEntity>>> Update(ImovelEntity entityEdit)
        {
            var listaEntities = new ServiceResponse<List<ImovelEntity>>();

            try
            {
                var entity = _context.Imoveis.AsNoTracking().FirstOrDefault(x => x.ImovelId == entityEdit.ImovelId);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }


                entity.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Imoveis.Update(entityEdit);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Imoveis.ToList();
                listaEntities.Mensagem = "Registro atualizado com sucesso";
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }
    }
}
