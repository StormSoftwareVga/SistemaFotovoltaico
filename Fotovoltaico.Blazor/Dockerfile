# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos de projeto e restaurar as dependências
COPY *.sln .
COPY Fotovoltaico/*.csproj ./Fotovoltaico/
COPY Fotovoltaico.Domain/*.csproj ./Fotovoltaico.Domain/
COPY Fotovoltaico.Infra.CrossCutting/*.csproj ./Fotovoltaico.Infra.CrossCutting/
COPY Fotovoltaico.Infra.CrossCutting.IoC/*.csproj ./Fotovoltaico.Infra.CrossCutting.IoC/
COPY Fotovoltaico.Infra.Data/*.csproj ./Fotovoltaico.Infra.Data/
COPY Fotovoltaico.Job/*.csproj ./Fotovoltaico.Job/
COPY Fotovoltaico.Tests/*.csproj ./Fotovoltaico.Tests/
COPY Fotovoltaico.BlazorServer/*.csproj ./Fotovoltaico.BlazorServer/
COPY Fotovoltaico.Blazor/*.csproj ./Fotovoltaico.Blazor/

# Restaurar as dependências
RUN dotnet restore

# Copiar o restante dos arquivos e compilar o Blazor
COPY . .
WORKDIR /app/Fotovoltaico.Blazor
RUN dotnet publish -c Release -o /app/out

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar a build do Blazor
COPY --from=build /app/out ./

# Expor a porta do Blazor
EXPOSE 5000

# Comando para rodar o Blazor
ENTRYPOINT ["dotnet", "Fotovoltaico.Blazor.dll"]
