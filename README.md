# 📘 API REST de Usuarios - ASP.NET Core + Entity Framework

---

## 📌 Descripción
Esta es una API REST creada con ASP.NET Core y Entity Framework Core para gestionar usuarios.

## Endpoints CRUD
### 🔹 Obtener todos los usuarios
GET `/api/usuarios`
### 🔹 Obtener usuario por ID
GET `/api/usuarios/{id}`
### 🔹 Crear usuario
POST `/api/usuarios`
### 🔹 Actualizar usuario existente
PUT `/api/usuarios/{id}`
### 🔹 Eliminar usuario por ID
DELETE `/api/usuarios/{id}`

---

## 🚀 Cómo ejecutar la API

1. Abrir el proyecto en Visual Studio
2. Verificar la cadena de conexión en `appsettings.json`
   - Si usas SQL Server local, normalmente es algo como:
     Data Source=LAPTOP-BJM;
     Initial Catalog=UsuarioDB;
3. Abrir la consola de NuGet Package Manager y ejecutar: Update-Database.
   - Esto creará la base de datos automáticamente.
4. Ejecutar el proyecto (F5).
5. Swagger se abrirá automáticamente en el navegador al ejecutar el proyecto
   
---

## 📬 Ejemplo JSON (POST / PUT)

```json
{
  "nombre": "Benja",
  "correo": "benja@gmail.com",
  "fechaDeNacimiento": "2026-05-30"
}
```

# 📸 Capturas en Swagger
<img width="1912" height="872" alt="image" src="https://github.com/user-attachments/assets/005279f3-8110-440d-a983-3f12e4ba949f" />

---


### 🔹 POST
- Click POST
- “Try it out”
- Pega JSON:
```json
{
  "nombre": "Benja",
  "correo": "benja@gmail.com",
  "fechaDeNacimiento": "2002-05-30"
}
```
<img width="1838" height="836" alt="image" src="https://github.com/user-attachments/assets/06332e9a-f2a3-4840-9b19-2d0c68c31577" />
<img width="1910" height="872" alt="image" src="https://github.com/user-attachments/assets/3b611d27-3136-4cf6-b899-85c12af1dd83" />

---


### 🔹 GET (Todos los usuarios)
- Click en GET
- “Try it out”
- “Execute”
<img width="1913" height="877" alt="image" src="https://github.com/user-attachments/assets/01419368-80bf-4675-96f1-ff78cdfeb49c" />
<img width="1907" height="864" alt="image" src="https://github.com/user-attachments/assets/aa8a71d2-bb9d-488e-a8c9-0b5566f4bfcf" />

---


### 🔹 GET (Usuario por ID)
- Click en GET
- Escribe el ID del usuario a buscar
- “Try it out”
- “Execute”
<img width="1884" height="861" alt="image" src="https://github.com/user-attachments/assets/12fd7404-a8f5-462a-a4a2-b4901e64779d" />
<img width="1889" height="874" alt="image" src="https://github.com/user-attachments/assets/8a2f208d-cfaf-4b4c-af50-fad813770a04" />

---


### 🔹 PUT
- Click en PUT
- Escribe el ID del usuario a actualizar
- “Try it out”
- Pega el JSON en el body:
{
  "id": 7,
  "nombre": "Benja",
  "correo": "benja@gmail.com",
  "fechaDeNacimiento": "2002-05-30"
}
- “Execute”
<img width="1883" height="866" alt="image" src="https://github.com/user-attachments/assets/b9e8c213-23bf-4b16-998b-21fcd372cd88" />
<img width="1862" height="852" alt="image" src="https://github.com/user-attachments/assets/e78cba8b-93f3-4c28-8f6c-a0f08b71730b" />

En caso de no encontrarlo:
<img width="1878" height="862" alt="image" src="https://github.com/user-attachments/assets/86ecd9df-d1ee-478c-9277-5b89c5854118" />
<img width="1854" height="858" alt="image" src="https://github.com/user-attachments/assets/ff2b5619-ccc9-4b80-ae7d-8f889d1dd5be" />

---


### 🔹 DELETE
- Click en DELETE
- Escribe el ID del usuario a eliminar
- “Try it out”
- “Execute”
<img width="1873" height="815" alt="image" src="https://github.com/user-attachments/assets/2ba24219-ad67-4e3e-8143-23633468d591" />
<img width="1877" height="832" alt="image" src="https://github.com/user-attachments/assets/1827306f-fda7-414b-a6b3-d1ec25c56efa" />

En caso de no encontrarlo:
<img width="1876" height="753" alt="image" src="https://github.com/user-attachments/assets/5e9953a5-7681-4722-b86b-fb38b6f8802f" />
<img width="1852" height="749" alt="image" src="https://github.com/user-attachments/assets/795947b6-9122-446c-a2d6-ccaba1f81c9b" />

---
