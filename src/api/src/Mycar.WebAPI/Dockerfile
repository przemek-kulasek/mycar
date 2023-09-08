#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Mycar/Mycar.WebAPI.csproj", "Mycar.WebAPI/"]
COPY ["Mycar/Mycar.Common.csproj", "Mycar.Common/"]
COPY ["Mycar/Mycar.Application.csproj", "Mycar.Application/"]
COPY ["Mycar/Mycar.Domain.csproj", "Mycar.Domain/"]
COPY ["Mycar/Mycar.Infrastructure.csproj", "Mycar.Infrastructure/"]
RUN dotnet restore "Mycar/Mycar.csproj"
COPY . .
WORKDIR "/src/Mycar.WebAPI"
RUN dotnet build "Mycar.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mycar.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mycar.WebAPI.dll"]