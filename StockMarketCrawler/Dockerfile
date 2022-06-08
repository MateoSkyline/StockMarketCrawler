#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
ENV TRIGGER_TIME=10 \
	DB_SERVER='192.168.1.200' \
	DB_PORT=5432 \
	DB_NAME='stockcrawler' \
	DB_USER='postgres' \
	DB_PASSWORD='docker'
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StockMarketCrawler.csproj", "."]
RUN dotnet restore "./StockMarketCrawler.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "StockMarketCrawler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockMarketCrawler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockMarketCrawler.dll"]