using Api.Domain.Interfaces.Inquilino;
using Api.Entities.Entity.Corretor;
using Api.Entities.Entity.Inquilinos;
using Api.Entities.Entity.ServiceResponse;
using Api.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Services.Inquilino
{
    public class InquilinoService : InquilinoInterface
    {
        private readonly AppDbContext _context;
        public InquilinoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<InquilinoEntity>>> GetAll()
        {
            var listaEntities = new ServiceResponse<List<InquilinoEntity>>();

            try
            {
                listaEntities.Dados = _context.Inquilinos.ToList();
                listaEntities.Mensagem = "Consulta realizada com sucesso";
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

        public async Task<ServiceResponse<InquilinoEntity>> GetEntityById(int id)
        {
            var entity = new ServiceResponse<InquilinoEntity>();

            try
            {
                var entityBase = _context.Inquilinos.FirstOrDefault(x => x.InquilinoId == id);

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
        public async Task<ServiceResponse<List<InquilinoEntity>>> Create(InquilinoEntity entity)
        {
            var listaEntities = new ServiceResponse<List<InquilinoEntity>>();

            try
            {

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Informar dados";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }

                _context.Inquilinos.Add(entity);
                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Inquilinos.ToList();
                listaEntities.Mensagem = "Registro cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<InquilinoEntity>>> Delete(int id)
        {
            var listaEntities = new ServiceResponse<List<InquilinoEntity>>();

            try
            {
                var entity = _context.Inquilinos.FirstOrDefault(x => x.InquilinoId == id);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }


                _context.Inquilinos.Remove(entity);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Inquilinos.ToList();
                listaEntities.Mensagem = "Registro deletado com sucesso";
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<InquilinoEntity>>> Inativa(int id)
        {
            var listaEntities = new ServiceResponse<List<InquilinoEntity>>();

            try
            {
                var entity = _context.Inquilinos.FirstOrDefault(x => x.InquilinoId == id);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }

                entity.Ativo = false;
                entity.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Inquilinos.Update(entity);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Inquilinos.ToList();
                listaEntities.Mensagem = "Registro inativado com sucesso";
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<InquilinoEntity>>> Update(InquilinoEntity entityEdit)
        {
            var listaEntities = new ServiceResponse<List<InquilinoEntity>>();

            try
            {
                var entity = _context.Inquilinos.AsNoTracking().FirstOrDefault(x => x.InquilinoId == entityEdit.InquilinoId);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }


                entity.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Inquilinos.Update(entityEdit);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Inquilinos.ToList();
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
