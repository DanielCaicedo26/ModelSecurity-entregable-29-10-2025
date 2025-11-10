# ModelSecurity

## 🐋 Ejecutar con Docker

Este proyecto incluye configuración completa de Docker para ejecutar la aplicación y las bases de datos.

### Inicio rápido

1. **Iniciar bases de datos:**
   ```bash
   cd BackEnd/ModelSecurity/DevOps
   docker-compose up -d
   ```

2. **Construir y ejecutar la aplicación:**
   ```bash
   cd BackEnd/ModelSecurity
   docker build -t modelsecurity-web:latest -f Web/Dockerfile .
   docker run -d --name modelsecurity-app -p 8080:8080 -p 8081:8081 --network devops_databases-net modelsecurity-web:latest
   ```

3. **Acceder a la aplicación:**
   - URL: http://localhost:8080

### 📖 Documentación completa de Docker

Para ver todos los comandos disponibles, opciones de configuración y solución de problemas, consulta la [Guía completa de Docker](DOCKER.md).

La guía incluye:
- Comandos para ejecutar y gestionar las bases de datos (SQL Server, PostgreSQL, MySQL)
- Comandos para construir y ejecutar la aplicación web
- Comandos útiles para debugging y mantenimiento
- Solución de problemas comunes
- Flujo de trabajo recomendado