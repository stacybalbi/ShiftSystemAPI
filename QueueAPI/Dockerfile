#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QueueAPI/Queue.API.csproj", "QueueAPI/"]
COPY ["Queue.Application/Queue.Application.csproj", "Queue.Application/"]
COPY ["Queue.Domain/Queue.Domain.csproj", "Queue.Domain/"]
COPY ["Queue.Infrastructure/Queue.Infrastructure.csproj", "Queue.Infrastructure/"]
RUN dotnet restore "QueueAPI/Queue.API.csproj"
COPY . .
WORKDIR "/src/QueueAPI"
RUN dotnet build "Queue.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Queue.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Queue.API.dll"]