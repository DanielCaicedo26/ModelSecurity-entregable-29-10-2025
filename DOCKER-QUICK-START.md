# 🚀 Inicio Rápido - Docker

## Comandos esenciales para ejecutar ModelSecurity con Docker

### 1️⃣ Iniciar las bases de datos

```bash
cd BackEnd/ModelSecurity/DevOps
docker-compose up -d
```

### 2️⃣ Verificar que las bases de datos estén corriendo

```bash
docker-compose ps
```

Deberías ver 3 contenedores en estado "Up" y "healthy":
- `sqlserver-modelsecurity`
- `postgres-modelsecurity`
- `mysql-modelsecurity`

### 3️⃣ Construir la aplicación web

```bash
cd ../
docker build -t modelsecurity-web:latest -f Web/Dockerfile .
```

### 4️⃣ Ejecutar la aplicación web

```bash
docker run -d \
  --name modelsecurity-app \
  -p 8080:8080 \
  -p 8081:8081 \
  --network devops_databases-net \
  modelsecurity-web:latest
```

### 5️⃣ Ver los logs de la aplicación

```bash
docker logs -f modelsecurity-app
```

Presiona `Ctrl+C` para salir de los logs.

### 6️⃣ Verificar que todo está funcionando

```bash
# Ver todos los contenedores en ejecución
docker ps
```

Accede a la aplicación en tu navegador:
- **URL:** http://localhost:8080

### 🛑 Detener todo

```bash
# Detener la aplicación
docker stop modelsecurity-app
docker rm modelsecurity-app

# Detener las bases de datos
cd BackEnd/ModelSecurity/DevOps
docker-compose down
```

---

## 📚 ¿Necesitas más información?

Consulta la [Guía Completa de Docker](DOCKER.md) para:
- Comandos detallados de cada servicio
- Cómo conectarse a las bases de datos
- Solución de problemas
- Comandos avanzados de Docker
- Flujo de trabajo completo

---

## ⚡ Comandos de un solo vistazo

```bash
# Iniciar todo desde cero
cd BackEnd/ModelSecurity/DevOps && docker-compose up -d
cd ../ && docker build -t modelsecurity-web:latest -f Web/Dockerfile .
docker run -d --name modelsecurity-app -p 8080:8080 -p 8081:8081 --network devops_databases-net modelsecurity-web:latest

# Ver el estado
docker ps

# Ver logs
docker logs -f modelsecurity-app

# Detener todo
docker stop modelsecurity-app && docker rm modelsecurity-app
cd BackEnd/ModelSecurity/DevOps && docker-compose down
```
