# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia todo el contenido del proyecto al contenedor
COPY . . 

# Restaura las dependencias
RUN dotnet restore

# Publica la aplicación en modo Release
RUN dotnet publish -c Release -o /out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia los archivos publicados desde la etapa anterior
COPY --from=build /out .

# Expone el puerto en el que correrá la aplicación
EXPOSE 8080

# VARIABLE DE ENTORNO prod
ENV ASPNETCORE_ENVIRONMENT=Production

# Comando de inicio de la aplicación
CMD ["dotnet", "Gestor.dll"]


