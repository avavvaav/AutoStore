
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG CONFIGURATION=Release
WORKDIR /src

COPY ["AutoStore.csproj", "./"]
RUN dotnet restore "AutoStore.csproj"

COPY . .
RUN dotnet build "AutoStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoStore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoStore.dll"]
