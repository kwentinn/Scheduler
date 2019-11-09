FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Scheduler/Scheduler.csproj", "Scheduler/"]
COPY ["Scheduler.Reporting/Scheduler.Reporting.csproj", "Scheduler.Reporting/"]
COPY ["Scheduler.Domain/Scheduler.Domain.csproj", "Scheduler.Domain/"]
RUN dotnet restore "Scheduler/Scheduler.csproj"
COPY . .
WORKDIR "/src/Scheduler"
RUN dotnet build "Scheduler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scheduler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scheduler.dll"]
