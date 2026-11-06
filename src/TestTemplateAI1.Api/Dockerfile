#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/TestTemplateAI1.Api/TestTemplateAI1.Api.csproj", "src/TestTemplateAI1.Api/"]
COPY ["src/TestTemplateAI1.Data/TestTemplateAI1.Data.csproj", "src/TestTemplateAI1.Data/"]
COPY ["src/TestTemplateAI1.Common/TestTemplateAI1.Common.csproj", "src/TestTemplateAI1.Common/"]
COPY ["src/TestTemplateAI1.Core/TestTemplateAI1.Core.csproj", "src/TestTemplateAI1.Core/"]
RUN dotnet restore "src/TestTemplateAI1.Api/TestTemplateAI1.Api.csproj"
COPY . .
WORKDIR "/src/src/TestTemplateAI1.Api"
RUN dotnet build "TestTemplateAI1.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplateAI1.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTemplateAI1.Api.dll"]