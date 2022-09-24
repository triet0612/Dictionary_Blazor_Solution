#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Dictionary_Blazor.Api/Dictionary_Blazor.Api.csproj", "Dictionary_Blazor.Api/"]
COPY ["Dictionary_Blazor.Models/Dictionary_Blazor.Models.csproj", "Dictionary_Blazor.Models/"]
RUN dotnet restore "Dictionary_Blazor.Api/Dictionary_Blazor.Api.csproj"
COPY . .
WORKDIR "/src/Dictionary_Blazor.Api"
RUN dotnet build "Dictionary_Blazor.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dictionary_Blazor.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dictionary_Blazor.Api.dll"]