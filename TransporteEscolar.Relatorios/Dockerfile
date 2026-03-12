FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

COPY src/TransporteEscolar.Relatorios.Api/TransporteEscolar.Relatorios.Api.csproj src/TransporteEscolar.Relatorios.Api/
COPY src/TransporteEscolar.Relatorios.Application/TransporteEscolar.Relatorios.Application.csproj src/TransporteEscolar.Relatorios.Application/
COPY src/TransporteEscolar.Relatorios.Domain/TransporteEscolar.Relatorios.Domain.csproj src/TransporteEscolar.Relatorios.Domain/
COPY src/TransporteEscolar.Relatorios.Infrastructure/TransporteEscolar.Relatorios.Infrastructure.csproj src/TransporteEscolar.Relatorios.Infrastructure/

RUN dotnet restore src/TransporteEscolar.Relatorios.Api/TransporteEscolar.Relatorios.Api.csproj

COPY src/ src/

RUN dotnet publish src/TransporteEscolar.Relatorios.Api/TransporteEscolar.Relatorios.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TransporteEscolar.Relatorios.Api.dll"]
