FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarDriveHelper.Swagger/CarDriveHelper.Swagger.csproj", "CarDriveHelper.Swagger/"]
RUN dotnet restore "CarDriveHelper.Swagger/CarDriveHelper.Swagger.csproj"
COPY . .
WORKDIR "/src/CarDriveHelper.Swagger"
RUN dotnet build "CarDriveHelper.Swagger.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarDriveHelper.Swagger.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarDriveHelper.Swagger.dll"]
