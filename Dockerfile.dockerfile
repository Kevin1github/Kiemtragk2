# Use official .NET runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use official .NET SDK as build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Kiemtragk2.csproj", "./"]
RUN dotnet restore "Kiemtragk2.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Kiemtragk2.csproj" -c Release -o /app/build
RUN dotnet publish "Kiemtragk2.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Kiemtragk2.dll"]
