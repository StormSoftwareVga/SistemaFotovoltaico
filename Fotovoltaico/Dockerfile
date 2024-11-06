# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos de projeto e restaura as dependências
COPY *.sln .
COPY Fotovoltaico/*.csproj ./Fotovoltaico/
COPY Fotovoltaico.Domain/*.csproj ./Fotovoltaico.Domain/
COPY Fotovoltaico.Infra.CrossCutting/*.csproj ./Fotovoltaico.Infra.CrossCutting/
COPY Fotovoltaico.Infra.CrossCutting.IoC/*.csproj ./Fotovoltaico.Infra.CrossCutting.IoC/
COPY Fotovoltaico.Infra.Data/*.csproj ./Fotovoltaico.Infra.Data/
COPY Fotovoltaico.Job/*.csproj ./Fotovoltaico.Job/
COPY Fotovoltaico.Tests/*.csproj ./Fotovoltaico.Tests/
RUN dotnet restore

# Copia o restante dos arquivos e compila a aplicação
COPY . .
WORKDIR /app/Fotovoltaico
RUN dotnet publish -c Release -o /app/out

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Fotovoltaico.Api.dll"]
