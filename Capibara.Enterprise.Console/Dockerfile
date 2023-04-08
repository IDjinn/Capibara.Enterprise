FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Capibara.Enterprise.Console/Capibara.Enterprise.Console.csproj", "Capibara.Enterprise.Console/"]
RUN dotnet restore "Capibara.Enterprise.Console/Capibara.Enterprise.Console.csproj"
COPY . .
WORKDIR "/src/Capibara.Enterprise.Console"
RUN dotnet build "Capibara.Enterprise.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Capibara.Enterprise.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Capibara.Enterprise.Console.dll"]
