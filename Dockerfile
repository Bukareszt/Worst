FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
WORKDIR /Backend
COPY ./ ./
RUN dotnet build -o ./bin

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS release
WORKDIR /Backend
COPY --from=builder /Backend/bin /Backend
ENTRYPOINT ["dotnet", "Backend.Console.dll"]
