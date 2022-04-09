FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FauntasticBack/FauntasticBack.csproj", "FauntasticBack/"]
RUN dotnet restore "FauntasticBack/FauntasticBack.csproj"
COPY . .
WORKDIR "/src/FauntasticBack"
RUN dotnet build "FauntasticBack.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FauntasticBack.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FauntasticBack.dll"]
