using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Relatorios.Api.Extensions;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.Services;
using TransporteEscolar.Relatorios.Infrastructure.DependencyInjection;
using TransporteEscolar.Relatorios.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IRelatorioMensalService, RelatorioMensalService>();
builder.Services.AddScoped<IFrequenciaAlunoService, FrequenciaAlunoService>();
builder.Services.AddScoped<IKmService, KmService>();
builder.Services.AddScoped<IIndicadorOperacionalService, IndicadorOperacionalService>();
builder.Services.AddScoped<ISyncHistoricoService, SyncHistoricoService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RelatoriosDbContext>();
    await db.Database.MigrateAsync();
}

app.UseGlobalExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();