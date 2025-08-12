

---

# **MiniManual – Ebanistería López**

**Nombre:** Malvin Rafael Lopez Salcedo

**Matrícula:** 2023-0032

**Semestre:** 2025-02

---

## **Usuarios de prueba**

**Administrador**

* **Email:** (Admin@gmail.com)
* **Contraseña:** 10014162004Ml@.

**Cliente**

* **Email:** Cliente@gmail.com
* **Contraseña:** Cliente@.16

---

## **Link del proyecto compilado**

🔗 https://ebanisterialopezproyectofinal-production-12da.up.railway.app/

---

## **¿Qué es Ebanistería López?**

**Ebanistería López** es una plataforma web interactiva desarrollada con **.NET 9** y **Blazor Server** para la gestión integral de un negocio de ebanistería.
Permite a **administradores** controlar productos, servicios, pedidos, cotizaciones y usuarios, mientras que **clientes** pueden navegar por un catálogo, agregar productos a un carrito, solicitar cotizaciones, agendar servicios y hacer seguimiento de sus pedidos.

La plataforma está optimizada para dispositivos móviles y de escritorio, con manejo de imágenes, autenticación segura y persistencia de datos.

---

## **Funcionalidades principales**

### **1. Gestión de Productos**

* Alta, modificación y eliminación de productos desde el panel administrador.
* Subida de múltiples imágenes por producto (almacenadas en Supabase).
* Clasificación por categorías (mesas, sillas, muebles, etc.).
* Definición del estado del producto: **Disponible**, **Agotado**, **Bajo pedido**.
* Búsqueda y filtrado en el catálogo.
* Visualización en la tienda pública con galería de imágenes.

---

### **2. Gestión de Servicios**

* Registro, edición y eliminación de servicios (ej. reparaciones, diseños personalizados).
* Definición de precio y descripción.
* Integración con el carrito para su compra.
* Vista pública de todos los servicios disponibles.

---

### **3. Tienda Online**

* Visualización de todos los productos con precio, imágenes y descripción.
* Botones dinámicos: *Añadir al carrito* o *Solicitar cotización*.
* Adaptación automática para móvil y escritorio.

---

### **4. Carrito de Compras**

* Añadir productos o servicios con cantidad.
* Eliminación individual o vaciado completo del carrito.
* Persistencia en memoria local (el carrito no se pierde al recargar la página).
* Cálculo automático de subtotal y total.
* Proceso de checkout con formulario de datos del cliente.

---

### **5. Cotizaciones**

* Solicitud de cotización para productos no disponibles o personalizados.
* El administrador recibe la solicitud y responde con precio y detalles por WhatsApp.
* Seguimiento de estado: **Pendiente**, **Respondida**, **Rechazada**.

---

### **6. Gestión de Pedidos**

* Registro automático de compras realizadas desde el carrito.
* Subida de comprobante de pago (si se paga por transferencia).
* Cambio de estado por parte del administrador:

  * Pedido recibido
  * En preparación
  * En camino
  * Entregado
* Historial de pedidos accesible para el cliente.

---

### **7. Gestión de Usuarios**

* Registro y login de clientes.
* Sistema de roles: **Administrador** y **Cliente**.
* Edición de datos de perfil.
* Restablecimiento de contraseña.

---

### **8. Sistema de Autenticación y Seguridad**

* Implementación de **Identity** para manejo de credenciales.
* Encriptación de contraseñas.
* Control de acceso a rutas según rol.
* Persistencia de sesión con *cookies*.

---

### **9. Gestión de Imágenes y Archivos**

* Almacenamiento en **Supabase Storage**.
* Compresión y ajuste automático de tamaño antes de subir.
* Recuperación de imágenes optimizada para carga rápida.

---



## **Tecnologías utilizadas**

* **.NET 8 / ASP.NET Core / Blazor Server** → Desarrollo de interfaz y lógica.
* **Entity Framework Core** → Acceso a base de datos SQL Server.
* **Identity** → Autenticación y autorización de usuarios.
* **Supabase** → Almacenamiento de imágenes y comprobantes.
* **Bootstrap 5** → Diseño responsivo y adaptado a móviles.
* **Radzen Blazor Components** → Notificaciones y elementos UI.

---

## **Estructura principal del proyecto**

* `/Services` → Lógica de negocio y acceso a datos (Productos, Servicios, Carrito, Pedidos, Cotizaciones, Chat, Usuarios).
* `/Components/Pages` → Páginas públicas y privadas (Tienda, Carrito, Checkout, Panel Admin, Chat).
* `/Data` → Modelos de base de datos y `ApplicationDbContext`.

---

## **¿Para quién es útil este proyecto?**

* Tiendas de ebanistería y carpintería.
* Negocios que vendan productos personalizados y bajo pedido.
* Comercios que combinen venta directa y servicios adicionales.
* Empresas que requieran un sistema de ventas + chat con clientes.


---

## **📸 Imágenes de Cliente**

|                                                                                                          |                                                                                                          |
| -------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| <img src="https://github.com/user-attachments/assets/1cf2baa2-429a-4fe2-8d83-bdaa08de695d" width="400"/> | <img src="https://github.com/user-attachments/assets/096fe72a-72e4-482a-8d9a-30bdb2f5c5d7" width="400"/> |
| <img src="https://github.com/user-attachments/assets/8d7e956a-9e72-492e-89c6-18ab3fc0e8ae" width="400"/> | <img src="https://github.com/user-attachments/assets/e8c2c4ab-2811-4273-801b-897ab87d8bea" width="400"/> |
| <img src="https://github.com/user-attachments/assets/9d7e57ee-e3f2-4ecb-9cbc-8ff6035a350c" width="400"/> | <img src="https://github.com/user-attachments/assets/605f8edc-207d-492e-ae3c-688e761f944d" width="400"/> |
| <img src="https://github.com/user-attachments/assets/355ab311-3e7c-4778-8c52-6ca1cd5f1908" width="400"/> | <img src="https://github.com/user-attachments/assets/7391dc14-8324-48df-8dbf-e211d7342d71" width="400"/> |

---

## **🛠️ Imágenes de Administrador**

|                                                                                                          |                                                                                                          |
| -------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| <img src="https://github.com/user-attachments/assets/18254501-ec51-46b8-a764-ee15846a0523" width="400"/> | <img src="https://github.com/user-attachments/assets/74c1bcee-75b4-4641-8c5d-718d306c6cbd" width="400"/> |
| <img src="https://github.com/user-attachments/assets/b190a173-601e-4d70-8b17-b3ac173fc912" width="400"/> | <img src="https://github.com/user-attachments/assets/4fe3e7b1-03b0-4d9c-b936-4d3342ce6897" width="400"/> |
| <img src="https://github.com/user-attachments/assets/e0989893-420d-4fdc-a619-5f2c7ccd170e" width="400"/> |                                                                                                          |

---











