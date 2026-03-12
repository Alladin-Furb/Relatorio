using TransporteEscolar.Relatorios.Api.Extensions;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.Services;
using TransporteEscolar.Relatorios.Infrastructure.DependencyInjection;

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