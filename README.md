# 📘 API REST implementando persistencia de datos con archivos - ASP.NET Core + Entity Framework

---

## 📌 Descripción
El sistema permite registrar usuarios en la base de datos y, adicionalmente, almacenar un registro serializado de cada usuario en un archivo de texto llamado `usuarios.txt`.

---

## 🚀 Implementación
Se creó una carpeta llamada Service que contiene la interfaz `IFileData` y la clase `FileData` que implementa dicha interfaz, encargadas de gestionar la persistencia de datos en archivos para luego cargarlos por medio del endpoint GET `/api/Usuario/FileData`..

Cada vez que se registra un usuario mediante el endpoint POST, el sistema:

- Guarda el usuario en la base de datos.
- Serializa la información del usuario.
- Almacena el registro en el archivo usuarios.txt.

Implementación dentro del método POST:

<img width="682" height="442" alt="image" src="https://github.com/user-attachments/assets/25e88c14-f053-4c51-aeeb-1c085210bc48" />

---

## Endpoints Consulta de archivo
Se agregó el endpoint:
```http
GET /api/Usuario/FileData
```

El Endpoints muestra los usuarios en el archivo, en caso de estar vacio o no existir mostrara el siguiente mensaje 
Este endpoint permite consultar los usuarios almacenados en el archivo usuarios.txt. Si el archivo no existe o no contiene registros, el sistema devolverá el siguiente mensaje:
```JSON
"No existen usuarios registrados."
```

Ejemplo de consulta:
<img width="1792" height="82" alt="image" src="https://github.com/user-attachments/assets/e4742451-84e5-4bf1-9821-f86fbc157888" />
<img width="1798" height="780" alt="image" src="https://github.com/user-attachments/assets/a1dc11d4-912a-4c47-b22a-40fe2dc98555" />

Los usuarios son almacenados de forma serializada dentro del archivo:

<img width="1880" height="217" alt="image" src="https://github.com/user-attachments/assets/3133a7ed-e99c-46ee-8dd7-74c2dec1358a" />

---

## Otros cambios menores implementados:
-- Cuando la base de datos no contiene registros en lugar de retornar una lista vacía el endpoint devuelve el mensaje: 
```JSON
"No existen usuarios registrados."
```

-- Se mejoró la validación de inicio de sesión. Si las credenciales no coinciden con ningún usuario registrado, el sistema responde con el mensaje:
```JSON
"Usuario no encontrado o no existe."
```
