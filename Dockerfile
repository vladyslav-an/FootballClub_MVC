FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestDemo/TestDemo.csproj", "TestDemo/"]
RUN dotnet restore "TestDemo/TestDemo.csproj"
COPY . .
WORKDIR "/src/TestDemo"
RUN dotnet build "TestDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDemo.dll"]
