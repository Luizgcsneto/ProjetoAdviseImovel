using Api.Domain.Interfaces.Corretor;
using Api.Entities.Entity.Corretor;
using Api.Entities.Entity.ServiceResponse;
using Api.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Services.Corretor
{
    public class CorretorService : ICorretorInterface
    {

        private readonly AppDbContext _context;

        public CorretorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CorretorEntity>>> GetAll()
        {
            var listaEntities = new ServiceResponse<List<CorretorEntity>>();
            listaEntities.Mensagem = "Consulta realizada com sucesso";
            try
            {
                listaEntities.Dados = _context.Corretores.ToList();

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

        public async Task<ServiceResponse<CorretorEntity>> GetEntityById(int id)
        {
            var entity = new ServiceResponse<CorretorEntity>();

            try
            {
                var entityBase = _context.Corretores.FirstOrDefault(x => x.CorretorId == id);

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

        public async Task<ServiceResponse<List<CorretorEntity>>> Create(CorretorEntity entity)
        {
            var listaEntities = new ServiceResponse<List<CorretorEntity>>();

            try
            {

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Informar dados";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }

                _context.Corretores.Add(entity);
                await _context.SaveChangesAsync();
                listaEntities.Dados = _context.Corretores.ToList();
                listaEntities.Mensagem = "Registro criado com sucesso";

            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<CorretorEntity>>> Delete(int id)
        {
            var listaEntities = new ServiceResponse<List<CorretorEntity>>();

            try
            {
                var entity = _context.Corretores.FirstOrDefault(x => x.CorretorId == id);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }


                _context.Corretores.Remove(entity);

                await _context.SaveChangesAsync();
                listaEntities.Mensagem = "Registro deletado com sucesso";
                listaEntities.Dados = _context.Corretores.ToList();

            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<CorretorEntity>>> Inativa(int id)
        {
            var listaEntities = new ServiceResponse<List<CorretorEntity>>();

            try
            {
                var entity = _context.Corretores.FirstOrDefault(x => x.CorretorId == id);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }

                entity.Ativo = false;
                entity.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Corretores.Update(entity);

                await _context.SaveChangesAsync();
                listaEntities.Mensagem = "Registro inativado com sucesso";
                listaEntities.Dados = _context.Corretores.ToList();

            }
            catch (Exception ex)
            {
                listaEntities.Mensagem = ex.Message;
                listaEntities.Sucesso = false;
            }

            return listaEntities;
        }

        public async Task<ServiceResponse<List<CorretorEntity>>> Update(CorretorEntity entityEdit)
        {
            var listaEntities = new ServiceResponse<List<CorretorEntity>>();

            try
            {
                var entity = _context.Corretores.AsNoTracking().FirstOrDefault(x => x.CorretorId == entityEdit.CorretorId);

                if (entity == null)
                {
                    listaEntities.Dados = null;
                    listaEntities.Mensagem = "Não foi encontrado resultado";
                    listaEntities.Sucesso = false;
                    return listaEntities;
                }


                entity.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Corretores.Update(entityEdit);

                await _context.SaveChangesAsync();
                listaEntities.Mensagem = "Registro atualizado com sucesso";
                listaEntities.Dados = _context.Corretores.ToList();

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
