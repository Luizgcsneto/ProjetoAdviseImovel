using Api.Domain.Interfaces.Proprietario;
using Api.Entities.Entity.Inquilinos;
using Api.Entities.Entity.Proprietario;
using Api.Entities.Entity.ServiceResponse;
using Api.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Services.Proprietario
{
    public class ProprietarioService : IProprietarioInterface
    {
        private readonly AppDbContext _context;
        public ProprietarioService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<ProprietarioEntity>>> GetAll()
        {
            var listaEntities = new ServiceResponse<List<ProprietarioEntity>>();
            listaEntities.Mensagem = "Consulta realizada com sucesso";

            try
            {
                listaEntities.Dados = _context.Proprietarios.ToList();

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

        public async Task<ServiceResponse<ProprietarioEntity>> GetEntityById(int id)
        {
            var entity = new ServiceResponse<ProprietarioEntity>();

            try
            {
                var entityBase = _context.Proprietarios.FirstOrDefault(x => x.ProprietarioId == id);

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
        public async Task<ServiceResponse<List<ProprietarioEntity>>> Create(ProprietarioEntity entity)
        {
            var listaEntities = new ServiceResponse<List<ProprietarioEntity>>();

            try
            {

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Informar dados";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }

                _context.Proprietarios.Add(entity);
                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Proprietarios.ToList();
                listaEntities.Mensagem = "Registro cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<ProprietarioEntity>>> Delete(int id)
        {
            var listaEntities = new ServiceResponse<List<ProprietarioEntity>>();

            try
            {
                var entity = _context.Proprietarios.FirstOrDefault(x => x.ProprietarioId == id);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }


                _context.Proprietarios.Remove(entity);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Proprietarios.ToList();
                listaEntities.Mensagem = "Registro deletado com sucesso";
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

     

        public async Task<ServiceResponse<List<ProprietarioEntity>>> Inativa(int id)
        {
            var listaEntities = new ServiceResponse<List<ProprietarioEntity>>();

            try
            {
                var entity = _context.Proprietarios.FirstOrDefault(x => x.ProprietarioId == id);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }

                entity.Ativo = false;
                entity.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Proprietarios.Update(entity);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Proprietarios.ToList();
                listaEntities.Mensagem = "Registro inativado com sucesso";
            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<ProprietarioEntity>>> Update(ProprietarioEntity entityEdit)
        {
            var listaEntities = new ServiceResponse<List<ProprietarioEntity>>();

            try
            {
                var entity = _context.Proprietarios.AsNoTracking().FirstOrDefault(x => x.ProprietarioId == entityEdit.ProprietarioId);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }


                entity.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Proprietarios.Update(entityEdit);

                await _context.SaveChangesAsync();

                listaEntities.Dados = _context.Proprietarios.ToList();
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
