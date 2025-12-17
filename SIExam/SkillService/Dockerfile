FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /SIExam

COPY SIExam/SkillService/SkillService.csproj .
RUN dotnet restore "SkillService.csproj"

COPY SIExam/SkillService/. .

RUN dotnet build "SkillService.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "SkillService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkillService.dll"]