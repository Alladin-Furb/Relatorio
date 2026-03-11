using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Infrastructure.Persistence.Context;
using TransporteEscolar.Relatorios.Infrastructure.Persistence.Repositories;

namespace TransporteEscolar.Relatorios.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RelatoriosDb");

        services.AddDbContext<RelatoriosDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IPresencaHistoricaRepository, PresencaHistoricaRepository>();
        services.AddScoped<IRotaHistoricaRepository, RotaHistoricaRepository>();

        return services;
    }
}