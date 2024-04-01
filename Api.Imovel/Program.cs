using Api.Domain.Interfaces.Corretor;
using Api.Domain.Interfaces.Imovel;
using Api.Domain.Interfaces.Inquilino;
using Api.Domain.Interfaces.Proprietario;
using Api.Domain.Services.Corretor;
using Api.Domain.Services.Imovel;
using Api.Domain.Services.Inquilino;
using Api.Domain.Services.Proprietario;
using Api.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IimovelInterface, ImovelService>();
builder.Services.AddScoped<ICorretorInterface, CorretorService>();
builder.Services.AddScoped<InquilinoInterface, InquilinoService>();
builder.Services.AddScoped<IProprietarioInterface, ProprietarioService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
