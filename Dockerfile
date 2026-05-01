# Etap budowania
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["RestApiLearning/RestApiLearning.csproj", "./"]

RUN dotnet restore "RestApiLearning/RestApiLearning.csproj"

COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Etap końcowy (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Tworzenie użytkownika nie-root (wersja dla Debiana)
RUN useradd -m -u 5678 appuser && chown -R appuser /app
USER appuser

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "RestApiLearning.dll"]