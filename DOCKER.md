# 🐋 Guía de Comandos Docker - ModelSecurity

Esta guía contiene todos los comandos necesarios para construir y ejecutar los contenedores Docker del proyecto ModelSecurity.

## 📋 Índice

1. [Requisitos Previos](#requisitos-previos)
2. [Bases de Datos (Docker Compose)](#bases-de-datos-docker-compose)
3. [Aplicación Web (Dockerfile)](#aplicación-web-dockerfile)
4. [Comandos Útiles](#comandos-útiles)
5. [Solución de Problemas](#solución-de-problemas)

---

## Requisitos Previos

Asegúrate de tener instalado:
- Docker Desktop (Windows/Mac) o Docker Engine (Linux)
- Docker Compose (incluido en Docker Desktop)

Verifica la instalación:
```bash
docker --version
docker-compose --version
```

---

## Bases de Datos (Docker Compose)

El proyecto incluye un archivo `docker-compose.yml` que configura tres bases de datos: SQL Server, PostgreSQL y MySQL.

### 🚀 Iniciar todos los servicios de bases de datos

```bash
cd BackEnd/ModelSecurity/DevOps
docker-compose up -d
```

### 🔍 Ver el estado de los contenedores

```bash
docker-compose ps
```

### 📊 Ver logs de los servicios

```bash
# Ver todos los logs
docker-compose logs

# Ver logs de un servicio específico
docker-compose logs sqlserver
docker-compose logs postgres
docker-compose logs mysql

# Seguir logs en tiempo real
docker-compose logs -f
```

### 🛑 Detener los servicios

```bash
# Detener sin eliminar los contenedores
docker-compose stop

# Detener y eliminar contenedores (los datos se mantienen en volúmenes)
docker-compose down

# Detener, eliminar contenedores y volúmenes (CUIDADO: elimina todos los datos)
docker-compose down -v
```

### 🔄 Reiniciar servicios

```bash
# Reiniciar todos los servicios
docker-compose restart

# Reiniciar un servicio específico
docker-compose restart sqlserver
```

### 📌 Conexiones a las bases de datos

**SQL Server:**
- Host: `localhost`
- Puerto: `1439`
- Usuario: `sa`
- Contraseña: `Admin123.`
- Comando de conexión:
  ```bash
  docker exec -it sqlserver-modelsecurity /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Admin123.
  ```

**PostgreSQL:**
- Host: `localhost`
- Puerto: `5439`
- Usuario: `postgres`
- Contraseña: `Admin123.`
- Base de datos: `modelSecurity`
- Comando de conexión:
  ```bash
  docker exec -it postgres-modelsecurity psql -U postgres -d modelSecurity
  ```

**MySQL:**
- Host: `localhost`
- Puerto: `3309`
- Usuario root: `root`
- Contraseña root: `Admin123.`
- Base de datos: `modelSecurity`
- Comando de conexión:
  ```bash
  docker exec -it mysql-modelsecurity mysql -uroot -pAdmin123. modelSecurity
  ```

---

## Aplicación Web (Dockerfile)

La aplicación web .NET se encuentra en `BackEnd/ModelSecurity/Web/` y tiene su propio Dockerfile.

### 🏗️ Construir la imagen de la aplicación

Desde el directorio raíz del backend:

```bash
cd BackEnd/ModelSecurity
docker build -t modelsecurity-web:latest -f Web/Dockerfile .
```

### 🚀 Ejecutar el contenedor de la aplicación

```bash
docker run -d \
  --name modelsecurity-app \
  -p 8080:8080 \
  -p 8081:8081 \
  --network devops_databases-net \
  modelsecurity-web:latest
```

Opciones del comando:
- `-d`: Ejecuta en segundo plano (detached mode)
- `--name`: Nombre del contenedor
- `-p 8080:8080`: Mapea el puerto 8080 del contenedor al puerto 8080 del host
- `-p 8081:8081`: Mapea el puerto 8081 del contenedor al puerto 8081 del host
- `--network`: Conecta al mismo network que las bases de datos

### 🔍 Ver logs de la aplicación

```bash
# Ver logs
docker logs modelsecurity-app

# Seguir logs en tiempo real
docker logs -f modelsecurity-app
```

### 🛑 Detener la aplicación

```bash
# Detener el contenedor
docker stop modelsecurity-app

# Eliminar el contenedor
docker rm modelsecurity-app
```

### 🔄 Reconstruir y ejecutar la aplicación

```bash
# Detener y eliminar contenedor anterior
docker stop modelsecurity-app
docker rm modelsecurity-app

# Reconstruir imagen
cd BackEnd/ModelSecurity
docker build -t modelsecurity-web:latest -f Web/Dockerfile .

# Ejecutar nuevo contenedor
docker run -d \
  --name modelsecurity-app \
  -p 8080:8080 \
  -p 8081:8081 \
  --network devops_databases-net \
  modelsecurity-web:latest
```

---

## Comandos Útiles

### 📦 Gestión de contenedores

```bash
# Listar contenedores en ejecución
docker ps

# Listar todos los contenedores (incluyendo detenidos)
docker ps -a

# Eliminar un contenedor
docker rm <nombre-o-id-contenedor>

# Eliminar todos los contenedores detenidos
docker container prune
```

### 🖼️ Gestión de imágenes

```bash
# Listar imágenes
docker images

# Eliminar una imagen
docker rmi <nombre-o-id-imagen>

# Eliminar imágenes sin usar
docker image prune

# Eliminar todas las imágenes sin usar (incluidas las sin etiqueta)
docker image prune -a
```

### 💾 Gestión de volúmenes

```bash
# Listar volúmenes
docker volume ls

# Inspeccionar un volumen
docker volume inspect <nombre-volumen>

# Eliminar un volumen
docker volume rm <nombre-volumen>

# Eliminar volúmenes sin usar
docker volume prune
```

### 🌐 Gestión de redes

```bash
# Listar redes
docker network ls

# Inspeccionar una red
docker network inspect devops_databases-net

# Crear una red
docker network create <nombre-red>
```

### 🔍 Inspección y debugging

```bash
# Acceder a la terminal de un contenedor
docker exec -it <nombre-contenedor> /bin/bash

# Inspeccionar un contenedor
docker inspect <nombre-contenedor>

# Ver estadísticas de recursos
docker stats

# Ver procesos en un contenedor
docker top <nombre-contenedor>
```

### 🧹 Limpieza general

```bash
# Eliminar todos los recursos sin usar (contenedores, redes, imágenes, caché)
docker system prune

# Limpieza completa incluyendo volúmenes
docker system prune -a --volumes

# Ver espacio usado por Docker
docker system df
```

---

## Solución de Problemas

### ❌ Error: "port is already allocated"

Si recibes un error indicando que el puerto ya está en uso:

```bash
# Verificar qué proceso está usando el puerto (Linux/Mac)
lsof -i :8080

# En Windows
netstat -ano | findstr :8080

# Detener el contenedor que usa el puerto
docker stop <nombre-contenedor>
```

### ❌ Error: "Cannot connect to the Docker daemon"

Asegúrate de que Docker Desktop esté en ejecución:

```bash
# Verificar estado de Docker
docker info
```

### ❌ Error al conectar a las bases de datos desde la aplicación

Verifica que:
1. Los contenedores de bases de datos estén en ejecución
2. La aplicación esté en la misma red que las bases de datos
3. Los strings de conexión en `appsettings.json` apunten a los nombres de los servicios:
   - `sqlserver-modelsecurity` en lugar de `localhost`
   - `postgres-modelsecurity` en lugar de `localhost`
   - `mysql-modelsecurity` en lugar de `localhost`

### ❌ Contenedores no saludables

Verifica el estado de salud:

```bash
docker ps

# Si un contenedor no es saludable, revisa los logs
docker logs <nombre-contenedor>
```

### 🔄 Resetear todo y empezar de nuevo

```bash
# Detener todos los contenedores
docker stop $(docker ps -a -q)

# Eliminar todos los contenedores
docker rm $(docker ps -a -q)

# Eliminar todas las imágenes
docker rmi $(docker images -q)

# Eliminar volúmenes (CUIDADO: perderás todos los datos)
docker volume prune -f

# Limpiar todo el sistema
docker system prune -a --volumes -f
```

---

## 📚 Recursos Adicionales

- [Documentación oficial de Docker](https://docs.docker.com/)
- [Docker Compose Reference](https://docs.docker.com/compose/compose-file/)
- [.NET Docker Images](https://hub.docker.com/_/microsoft-dotnet)
- [SQL Server Docker Hub](https://hub.docker.com/_/microsoft-mssql-server)
- [PostgreSQL Docker Hub](https://hub.docker.com/_/postgres)
- [MySQL Docker Hub](https://hub.docker.com/_/mysql)

---

## 🎯 Flujo de trabajo recomendado

1. **Iniciar bases de datos:**
   ```bash
   cd BackEnd/ModelSecurity/DevOps
   docker-compose up -d
   ```

2. **Verificar que las bases de datos estén saludables:**
   ```bash
   docker-compose ps
   ```

3. **Construir la aplicación:**
   ```bash
   cd ../
   docker build -t modelsecurity-web:latest -f Web/Dockerfile .
   ```

4. **Ejecutar la aplicación:**
   ```bash
   docker run -d \
     --name modelsecurity-app \
     -p 8080:8080 \
     -p 8081:8081 \
     --network devops_databases-net \
     modelsecurity-web:latest
   ```

5. **Verificar que todo esté funcionando:**
   ```bash
   docker ps
   docker logs modelsecurity-app
   ```

6. **Acceder a la aplicación:**
   - Abre tu navegador en `http://localhost:8080`

7. **Detener todo cuando termines:**
   ```bash
   docker stop modelsecurity-app
   cd DevOps
   docker-compose down
   ```
