FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["Heroes of Might and Magic.csproj", "./"]

RUN dotnet restore "Heroes of Might and Magic.csproj"

COPY . .

RUN dotnet publish "Heroes of Might and Magic.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore


FROM mcr.microsoft.com/dotnet/runtime:10.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Heroes of Might and Magic.dll"]