FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ./SmqApp.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o /out
FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ConnectionStrings__MariaDb="Server=mariadb;Port=3306;Database=pocdb;User Id=pocuser;Password=StrongPassword123!;TreatTinyAsBoolean=false;SslMode=None"
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "SmqApp.dll"]
