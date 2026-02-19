# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["badminton4all.csproj", "./"]
RUN dotnet restore "badminton4all.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "badminton4all.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "badminton4all.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Copy published files from publish stage
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "badminton4all.dll"]
