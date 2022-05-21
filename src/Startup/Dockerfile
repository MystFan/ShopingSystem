FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Startup/ShopingRequestSystem.Startup.csproj", "Startup/"]
COPY ["Web/ShopingRequestSystem.Web.csproj", "Web/"]
COPY ["Application/ShopingRequestSystem.Queries/ShopingRequestSystem.Queries.csproj", "Application/ShopingRequestSystem.Queries/"]
COPY ["Domain/ShopingRequestSystem.Domain.PublishedRequests/ShopingRequestSystem.Domain.PublishedRequests.csproj", "Domain/ShopingRequestSystem.Domain.PublishedRequests/"]
COPY ["Domain/ShopingRequestSystem.Domain.Common/ShopingRequestSystem.Domain.Common.csproj", "Domain/ShopingRequestSystem.Domain.Common/"]
COPY ["Domain/ShopingRequestSystem.Domain.RequestExecutions/ShopingRequestSystem.Domain.RequestExecutions.csproj", "Domain/ShopingRequestSystem.Domain.RequestExecutions/"]
COPY ["Domain/ShopingRequestSystem.Domain.Requests/ShopingRequestSystem.Domain.Requests.csproj", "Domain/ShopingRequestSystem.Domain.Requests/"]
COPY ["Application/ShopingRequestSystem.Application/ShopingRequestSystem.Application.csproj", "Application/ShopingRequestSystem.Application/"]
COPY ["Domain/ShopingRequestSystem.Domain.Identity/ShopingRequestSystem.Domain.Identity.csproj", "Domain/ShopingRequestSystem.Domain.Identity/"]
COPY ["Infrastructure/ShopingRequestSystem.Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "Startup/ShopingRequestSystem.Startup.csproj"
COPY . .
WORKDIR "/src/Startup"
RUN dotnet build "ShopingRequestSystem.Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopingRequestSystem.Startup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopingRequestSystem.Startup.dll"]