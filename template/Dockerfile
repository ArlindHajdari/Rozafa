# Use the official Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/Rozafa.API/Rozafa.API.csproj", "Rozafa.API/"]
COPY ["src/Rozafa.Contracts/Rozafa.Contracts.csproj", "Rozafa.Contracts/"]
COPY ["src/Rozafa.Infrastructure/Rozafa.Infrastructure.csproj", "Rozafa.Infrastructure/"]
COPY ["src/Rozafa.Domain/Rozafa.Domain.csproj", "Rozafa.Domain/"]
COPY ["src/Rozafa.Application/Rozafa.Application.csproj", "Rozafa.Application/"]

RUN dotnet restore "Rozafa.API/Rozafa.API.csproj"

COPY . .

WORKDIR "Rozafa.API"
RUN dotnet build "Rozafa.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rozafa.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Rozafa.API.dll"]