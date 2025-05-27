# Dockerfile Development
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
EXPOSE 8080

COPY . /app
RUN dotnet restore

COPY . ./

ENTRYPOINT [ "dotnet", "watch", "run", "--project", "src/LojaManoel.Api/LojaManoel.Api.csproj", "--urls", "http://*:8080"]