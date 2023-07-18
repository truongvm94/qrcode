FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

RUN mkdir /app

COPY QRCodeCore.csproj /app/QRCodeCore.csproj

WORKDIR /app

RUN dotnet restore QRCodeCore.csproj --disable-parallel

COPY . /app/

RUN dotnet publish QRCodeCore.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

RUN mkdir /app
WORKDIR /app
COPY --from=build /app/publish .

RUN apt-get update && apt-get install -y libgdiplus

# RUN apt-get update -y && apt-get install -y wget ca-certificates gnupg

# RUN wget --quiet -O - https://www.postgresql.org/media/keys/ACCC4CF8.asc | gpg --dearmor --yes --output /usr/share/keyrings/apt.postgresql.org-archive-keyring.gpg

# RUN echo "deb [signed-by=/usr/share/keyrings/apt.postgresql.org-archive-keyring.gpg] http://apt.postgresql.org/pub/repos/apt/ bullseye-pgdg main" > /etc/apt/sources.list.d/pgdg.list

# RUN apt-get update && apt-get install -y postgresql-client-14

EXPOSE 80

ENTRYPOINT [ "dotnet","QRCodeCore.dll" ]
