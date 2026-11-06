#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/TestTemplateAI1.WorkerServices/TestTemplateAI1.WorkerServices.csproj", "src/TestTemplateAI1.WorkerServices/"]
COPY ["src/TestTemplateAI1.Core/TestTemplateAI1.Core.csproj", "src/TestTemplateAI1.Core/"]
COPY ["src/TestTemplateAI1.Common/TestTemplateAI1.Common.csproj", "src/TestTemplateAI1.Common/"]
RUN dotnet restore "src/TestTemplateAI1.WorkerServices/TestTemplateAI1.WorkerServices.csproj"
COPY . .
WORKDIR "/src/src/TestTemplateAI1.WorkerServices"
RUN dotnet build "TestTemplateAI1.WorkerServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplateAI1.WorkerServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/TestTemplateAI1.WorkerServices/entrypoint.sh", "src/entrypoint.sh"]
COPY ["src/TestTemplateAI1.WorkerServices/wait-for-it.sh", "src/wait-for-it.sh"]
CMD ["/bin/bash", "src/entrypoint.sh"]
