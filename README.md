# 📘 API REST implementando entidades productos - ASP.NET Core + Entity Framework

---

## 📌 Descripción
El sistema permite administrar productos, proveedores y categorías, además de realizar consultas estadísticas y filtros personalizados sobre los 
productos registrados.

## Endpoints Consulta Especiales
### 🔹 Estadísticas de Productos
Endpoint que devuelve:

- Producto con el precio más alto.
- Producto con el precio más bajo.
- Suma total de los precios de todos los productos.
- Precio promedio de todos los productos.
<img width="1815" height="690" alt="image" src="https://github.com/user-attachments/assets/9f8a7b30-6d22-4d62-8e78-3d4cbad1d107" />
<img width="1863" height="838" alt="image" src="https://github.com/user-attachments/assets/3ca946b3-5d9e-46eb-80f3-a43549463d0a" />


### 🔹 Productos por Categoría
Permite obtener todos los productos pertenecientes a una categoría específica.
<img width="1872" height="822" alt="image" src="https://github.com/user-attachments/assets/3c5fe474-1e82-4476-b4f6-bfb4aa4a877a" />
<img width="1858" height="820" alt="image" src="https://github.com/user-attachments/assets/8544da78-c524-4534-9c3d-c51e119e0aef" />


### 🔹 Productos por Proveedor
Permite obtener todos los productos suministrados por un proveedor específico.
<img width="1842" height="676" alt="image" src="https://github.com/user-attachments/assets/74921ce4-224c-4fb6-a167-daff3eaa648c" />
<img width="1861" height="817" alt="image" src="https://github.com/user-attachments/assets/537f75fb-75f7-4ab8-a049-71275cb06c6f" />


### 🔹 Cantidad Total de Productos
Permite conocer la cantidad total de productos registrados en el sistema.
<img width="1847" height="840" alt="image" src="https://github.com/user-attachments/assets/e14aeaa4-5762-4234-9c3a-0a0655eb9b16" />


---

## 🚀 Implementación

Las consultas especiales fueron desarrolladas utilizando LINQ y expresiones Lambda para optimizar el acceso a los datos y mantener un código limpio y 
fácil de mantener.

Además, se utilizaron DTOs para evitar exponer directamente las entidades y prevenir problemas de serialización relacionados con las relaciones entre tablas.
