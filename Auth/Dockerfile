# === Runtime Image (slim) ===
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# App will run on HTTPS port 7087 and HTTP port 5000
EXPOSE 7087
EXPOSE 7077
ENV ASPNETCORE_URLS="https://+:7077;http://+:7087"

# These two env variables tell Kestrel where to find the HTTPS cert
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password

# === Build Image (full SDK) ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files first
COPY ["Auth/Auth.csproj", "Auth/"]
COPY ["OrderSharedContent/OrderSharedContent.csproj", "OrderSharedContent/"]

# Restore dependencies
RUN dotnet restore "./Auth/Auth.csproj"

# Copy everything
COPY . .

# Generate dev cert (to be used in runtime stage)
RUN dotnet dev-certs https -ep aspnetapp.pfx -p password

# Build the app
WORKDIR "/src/Auth"
RUN dotnet build "./Auth.csproj" -c $BUILD_CONFIGURATION -o /app/build

# === Publish Stage ===
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Auth.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# === Final Runtime Stage ===
FROM base AS final
WORKDIR /app

# Copy published output
COPY --from=publish /app/publish .

# Copy the generated certificate into container
COPY --from=build /src/aspnetapp.pfx /https/aspnetapp.pfx

# Start the app
ENTRYPOINT ["dotnet", "Auth.dll"]
