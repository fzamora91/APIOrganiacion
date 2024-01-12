"# APIOrganiacion" 
Para usar el api primero debe generar un token
https://localhost:44352/api/Auth
{
  "UserName":"andres",
  "Password":"12345"
}

luego debe ingresar el token para cada uno de los endpoint
https://localhost:44352/api/Producto/Create
{
  "nombre_Producto": "Pencil",
  "precio": 25,
  "creado_Por": "Admin",
  "modificado_Por": "Admin"
}

tambien puede usar el tenant 
https://localhost:44352/api/Producto/Get?tenant=OrganizacionUsuario
https://localhost:44352/api/Producto/Get?tenant=OrganizacionProducto
