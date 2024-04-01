using Api.Entities.Entity.Corretor;
using Api.Entities.Entity.Imovel;
using Api.Entities.Entity.Inquilinos;
using Api.Entities.Entity.Proprietario;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<ImovelEntity> Imoveis { get; set; }
        public DbSet<InquilinoEntity> Inquilinos { get; set; }
        public DbSet<ProprietarioEntity> Proprietarios { get; set; }
        public DbSet<CorretorEntity> Corretores { get; set; }

     

    }
}
