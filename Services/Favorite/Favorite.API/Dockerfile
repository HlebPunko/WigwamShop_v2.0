FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Favorite/Favorite.API/Favorite.API.csproj", "Services/Favorite/Favorite.API/"]
COPY ["Services/Favorite/Favorite.Application/Favorite.Application.csproj", "Services/Favorite/Favorite.Application/"]
COPY ["Services/Favorite/Favorite.Domain/Favorite.Domain.csproj", "Services/Favorite/Favorite.Domain/"]
COPY ["Services/Favorite/Favorite.Infostructure/Favorite.Infostructure.csproj", "Services/Favorite/Favorite.Infostructure/"]
RUN dotnet restore "Services/Favorite/Favorite.API/Favorite.API.csproj"
COPY . .
WORKDIR "/src/Services/Favorite/Favorite.API"
RUN dotnet build "Favorite.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Favorite.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Favorite.API.dll"]