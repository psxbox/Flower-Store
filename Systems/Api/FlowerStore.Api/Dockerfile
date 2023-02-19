#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/FlowerStore.Api/FlowerStore.Api.csproj", "Systems/Api/FlowerStore.Api/"]
COPY ["Shared/AppSettings/AppSettings.csproj", "Shared/AppSettings/"]
COPY ["Services/FlowerStore.Services.Settings/FlowerStore.Services.Settings.csproj", "Services/FlowerStore.Services.Settings/"]
COPY ["Services/FlowerStore.Services.Flowers/FlowerStore.Services.Flowers.csproj", "Services/FlowerStore.Services.Flowers/"]
COPY ["Data/FlowerStore.Context.Entities/FlowerStore.Context.Entities.csproj", "Data/FlowerStore.Context.Entities/"]
RUN dotnet restore "Systems/Api/FlowerStore.Api/FlowerStore.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/FlowerStore.Api"
RUN dotnet build "FlowerStore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlowerStore.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlowerStore.Api.dll"]