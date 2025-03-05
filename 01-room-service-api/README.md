# Room Service Authorization API

## Descripción
Room Service Authorization API es una aplicación RESTful desarrollada en .NET Core que proporciona una interfaz para la gestión de habitaciones de hotel. La API incluye funcionalidades para crear habitaciones, obtener listas de habitaciones (con posibilidad de filtrado por pisos) y obtener detalles de habitaciones específicas por ID.

Además, implementa un middleware de autorización personalizado que verifica la presencia de un encabezado de autenticación específico en cada solicitud.

## Tecnologías utilizadas
- .NET 6
- ASP.NET Core Web API
- xUnit para pruebas unitarias

## Requisitos
- .NET SDK 6.0 o superior

## Instalación

### Clonar el repositorio
```bash
git clone https://github.com/[tu-usuario]/room-service-authorization.git
cd room-service-authorization
```

### Compilar la solución
```bash
dotnet build
```

### Ejecutar las pruebas
```bash
dotnet test
```

### Ejecutar la aplicación
```bash
cd RoomService.WebAPI
dotnet run
```

## Estructura del proyecto
```
RoomService/
├── RoomService.WebAPI/             # Proyecto principal de la API
│   ├── Controllers/                # Controladores de la API
│   │   └── RoomsController.cs      # Controlador para gestionar habitaciones
│   ├── Extensions/                 # Extensiones de ASP.NET Core
│   │   └── AuthorizationMiddlewareExtensions.cs
│   ├── Middleware/                 # Middleware personalizado
│   │   └── AuthorizationMiddleware.cs  # Middleware de autorización
│   ├── Models/                     # Modelos de datos
│   │   └── Room.cs                 # Modelo de habitación
│   └── Program.cs                  # Punto de entrada y configuración
└── RoomService.Tests/              # Proyecto de pruebas unitarias
    └── RoomsControllerTests.cs     # Pruebas para el controlador de habitaciones
```

## Endpoints de la API

### Crear una habitación
- **URL**: `/api/rooms`
- **Método**: `POST`
- **Headers requeridos**: `passwordKey: passwordKey123456789`
- **Body**: Objeto JSON con los detalles de la habitación
- **Respuesta exitosa**: Código 201 (Created)
- **Ejemplo de solicitud**:
```bash
curl -X POST -H "Content-Type: application/json" -H "passwordKey: passwordKey123456789" -d '{
  "id": 1,
  "category": "Luxe",
  "number": 122,
  "floor": 3,
  "isAvailable": true,
  "addedDate": 1573843210
}' https://localhost:7068/api/rooms
```

### Obtener todas las habitaciones
- **URL**: `/api/rooms`
- **Método**: `GET`
- **Headers requeridos**: `passwordKey: passwordKey123456789`
- **Respuesta exitosa**: Código 200 (OK)
- **Ejemplo de solicitud**:
```bash
curl -H "passwordKey: passwordKey123456789" https://localhost:7068/api/rooms
```

### Filtrar habitaciones por piso
- **URL**: `/api/rooms?Floors={floor1}&Floors={floor2}`
- **Método**: `GET`
- **Headers requeridos**: `passwordKey: passwordKey123456789`
- **Respuesta exitosa**: Código 200 (OK)
- **Ejemplo de solicitud**:
```bash
curl -H "passwordKey: passwordKey123456789" "https://localhost:7068/api/rooms?Floors=1&Floors=3"
```

### Obtener una habitación por ID
- **URL**: `/api/rooms/{id}`
- **Método**: `GET`
- **Headers requeridos**: `passwordKey: passwordKey123456789`
- **Respuesta exitosa**: Código 200 (OK)
- **Ejemplo de solicitud**:
```bash
curl -H "passwordKey: passwordKey123456789" https://localhost:7068/api/rooms/1
```

## Middleware de autorización
La API implementa un middleware de autorización personalizado que verifica la presencia del encabezado `passwordKey` con el valor `passwordKey123456789` en cada solicitud. Si este encabezado no está presente o tiene un valor incorrecto, la API responde con un código de estado 403 (Forbidden).

## Uso de la aplicación
1. Ejecuta la aplicación usando `dotnet run` desde el directorio RoomService.WebAPI
2. La API estará disponible en:
   - HTTPS: https://localhost:7068/api/rooms
   - HTTP: http://localhost:5242/api/rooms (redirecciona a HTTPS)
3. Utiliza curl, Postman u otra herramienta para realizar solicitudes a la API

## Pruebas
El proyecto incluye pruebas unitarias para verificar el funcionamiento del controlador de habitaciones. Estas pruebas validan:
- La creación de habitaciones
- La obtención de habitaciones por ID
- El manejo de IDs no existentes
- El filtrado de habitaciones por piso

Puedes ejecutar las pruebas con el comando:
```bash
dotnet test
```

## Mejoras futuras potenciales
- Implementar una base de datos persistente
- Agregar endpoints para actualizar y eliminar habitaciones
- Mejorar la autenticación (JWT)
- Agregar documentación de API con Swagger
- Implementar validación más robusta
- Configurar CI/CD

## Autor
[ Manuel Giovanni Cortazar De La Cruz]
