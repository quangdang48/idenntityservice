# ---- Stage 1: Build ----
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src

# Copy csproj để cache restore
COPY IndentityService/*.csproj IndentityService/
RUN dotnet restore IndentityService/IndentityService.csproj

# Copy toàn bộ source và build
COPY IndentityService/. IndentityService/
RUN dotnet publish IndentityService/IndentityService.csproj -c Release -o /app/publish

# ---- Stage 2: Runtime ----
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "IndentityService.dll"]
