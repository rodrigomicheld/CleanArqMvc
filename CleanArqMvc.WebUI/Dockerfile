#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CleanArqMvc.WebUI/CleanArqMvc.WebUI.csproj", "CleanArqMvc.WebUI/"]
RUN dotnet restore "CleanArqMvc.WebUI/CleanArqMvc.WebUI.csproj"
COPY . .
WORKDIR "/src/CleanArqMvc.WebUI"
RUN dotnet build "CleanArqMvc.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArqMvc.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArqMvc.WebUI.dll"]