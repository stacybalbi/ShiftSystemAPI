#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QueuePerson.API/QueuePerson.API.csproj", "QueuePerson.API/"]
COPY ["Queue.Application/Queue.Application.csproj", "Queue.Application/"]
COPY ["Queue.Domain/Queue.Domain.csproj", "Queue.Domain/"]
COPY ["QueuePerson.Application/QueuePerson.Application.csproj", "QueuePerson.Application/"]
COPY ["QueuePerson.Domain/QueuePerson.Domain.csproj", "QueuePerson.Domain/"]
COPY ["Person.Domain/Person.Domain.csproj", "Person.Domain/"]
COPY ["QueuePerson.Infrastructure/QueuePerson.Infrastructure.csproj", "QueuePerson.Infrastructure/"]
RUN dotnet restore "QueuePerson.API/QueuePerson.API.csproj"
COPY . .
WORKDIR "/src/QueuePerson.API"
RUN dotnet build "QueuePerson.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QueuePerson.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QueuePerson.API.dll"]