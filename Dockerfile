﻿FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "Capibara.Enterprise.Presentation.Console.dll"]