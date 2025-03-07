# Use official .NET runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use official .NET SDK as build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Ktrgk2.csproj", "./"]
RUN dotnet restore "Ktrgk2.csproj"  # Đã sửa lại đúng tên file

COPY . .
WORKDIR "/src"
RUN dotnet build "Ktrgk2.csproj" -c Release -o /app/build
RUN dotnet publish "Ktrgk2.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Ktrgk2.dll"]  # Kiểm tra tên file .dll đúng chưa!
