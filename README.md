
# API de Gestión de Usuarios con JWT

## Descripción
Esta rama de la API, de gestión de usuarios mediante operaciones CRUD, implementa autenticación basada en JWT (JSON Web Token) para proteger los endpoints 
y controlar el acceso a los recursos.

---

## Configuración

La aplicación utiliza una cadena de conexión a SQL Server y una clave secreta para la generación y validación de tokens JWT.

Configuración JWT
```JSON
"settings": {
    "secretkey": "MiClaveSuperSecretaJWT2026ParaLaAPI"
}
```

---

## Autenticación

### Registrar Usuario

POST /api/Acceso/Registrarse

Body

```JSON
{
    "nombreUsuario": "Benjamin",
    "contraseña": "12345678"
}
```

### Iniciar Sesión

POST /api/Acceso/Login

Body

```JSON
{
    "nombreUsuario": "Benjamin",
    "contraseña": "12345678"
}
```

Respuesta

```JSON
{
    "isSuccess": true,
    "token": "JWT_GENERADO"
}
```

### Refrescar Token

POST /api/Acceso/RefreshToken

Este endpoint genera un nuevo JWT utilizando la información del usuario autenticado. A este solo se puede acceder una vez nos hemos logeado.

<img width="1808" height="284" alt="image" src="https://github.com/user-attachments/assets/88be482f-0497-46d4-9583-223f325adf59" />

---

## Endpoints Protegidos
Todos los endpoints del controlador `UsuarioController` están protegidos mediante el atributo `[Authorize]`.

- Obtener todos los usuarios
- Obtener usuario por ID
- Crear usuario
- Actualizar usuario
- Eliminar usuario

En caso de utilizar alguno de los endpoints anteriores sin haberse autenticado previamente, la API devolverá un error 401 (Unauthorized):

<img width="1787" height="668" alt="image" src="https://github.com/user-attachments/assets/e99b3ef7-a9ca-4afb-bb9a-ff06d291cc8e" />

---

## Validaciones Implementadas

Se utilizaron DataAnnotations para validar los datos de entrada.

UsuarioDTO
- Required
- MinLength

Ejemplo:

```csharp
[Required(ErrorMessage = "La contraseña es requerida")]
[MinLength(8, ErrorMessage = "La contraseña no puede contener menos de 8 caracteres.")]
public string contraseña { get; set; }
```

---

## Cómo Utilizar la API
1. Registrar un usuario mediante el endpoint Registrarse.
<img width="1815" height="841" alt="image" src="https://github.com/user-attachments/assets/a3f8023b-8959-4126-9673-1f2dfc734468" />

`Si nos lanza "true" es que se guardo.`
<img width="1795" height="497" alt="image" src="https://github.com/user-attachments/assets/b672482d-a676-4bd5-99cc-40b0c3b6b441" />

2. Iniciar sesión utilizando el endpoint Login.
<img width="1818" height="749" alt="image" src="https://github.com/user-attachments/assets/3936bed1-5fde-496e-9e7a-dde38cd8cfa9" />

3. Copiar el token JWT generado.
<img width="1773" height="677" alt="image" src="https://github.com/user-attachments/assets/9c34f9ba-c8de-4bf4-ba03-ea1da443025b" />

4. Presionar el botón Authorize en Swagger.
<img width="1793" height="259" alt="image" src="https://github.com/user-attachments/assets/8eadbcc5-a04f-4ae8-a3ad-2fdbf02f3abc" />

5. Introducir el token en el formato:
<img width="1540" height="565" alt="image" src="https://github.com/user-attachments/assets/b9f83cbd-e343-41a5-ad36-12a48c045d85" />
<img width="1023" height="483" alt="image" src="https://github.com/user-attachments/assets/3ce0a4a0-3f6d-4ed4-aa2f-ef5a093e0d05" />

6. Ya podemos usar los demas Endpoints de UsuarioController:
<img width="1876" height="872" alt="image" src="https://github.com/user-attachments/assets/21784f16-9d0e-4da3-a0ef-27b93eaf99f1" />

7. Utilizar el endpoint RefreshToken para generar un nuevo token cuando sea necesario.
<img width="1866" height="855" alt="image" src="https://github.com/user-attachments/assets/ed0a4848-79c3-4d26-88ce-4f377de104bd" />

## Restricciones y Seguridad
- Las contraseñas se almacenan utilizando encriptación SHA-256.
- La contraseña debe contener al menos 8 caracteres.
- Los tokens poseen una fecha de expiración y dejan de ser válidos una vez alcanzado el tiempo límite.
- Solo los usuarios autenticados pueden acceder a los recursos protegidos.
