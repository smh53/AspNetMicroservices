#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Discount/Discout.Grpc/Discout.Grpc.csproj", "Services/Discount/Discout.Grpc/"]
RUN dotnet restore "Services/Discount/Discout.Grpc/Discout.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/Discount/Discout.Grpc"
RUN dotnet build "Discout.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discout.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discout.Grpc.dll"]