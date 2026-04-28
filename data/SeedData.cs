using ProyectoInventario.models;
using ProyectoInventario.repositories;

public static class SeedData
{
    public static void Initialize(IServiceProvider services)
    {
        // Obtenemos los repositorios del contenedor de dependencias
        var categoriaRepo = services.GetRequiredService<ICategoriaRepository>();
        var productoRepo  = services.GetRequiredService<IProductoRepository>();
        var usuarioRepo   = services.GetRequiredService<IUsuarioRepository>();
        var proveedorRepo = services.GetRequiredService<IProveedorRepository>();
        var inventarioRepo = services.GetRequiredService<IInventarioRepository>();

        // ── 1. CATEGORÍAS ──────────────────────────────────────────
        var catCafe   = new Categoria("Café");
        var catDulces = new Categoria("Dulces");
        var catGalletas = new Categoria("Galletas");

        categoriaRepo.Add(catCafe);
        categoriaRepo.Add(catDulces);
        categoriaRepo.Add(catGalletas);

        // ── 2. PRODUCTOS ───────────────────────────────────────────
        var cafe250 = new ProductoCafe(
            nombre: "Café molido 250g",
            precio: 15000,
            stock: 30,
            variante: "250g",
            esMolido: true,
            costo: 9000
        );
        cafe250.AsignarCategoria(catCafe);
        catCafe.AgregarProducto(cafe250);

        var cafeGrano = new ProductoCafe(
            nombre: "Café en grano 500g",
            precio: 28000,
            stock: 5,           // bajo stock a propósito para probar ese filtro
            variante: "500g",
            esMolido: false,
            costo: 16000
        );
        cafeGrano.AsignarCategoria(catCafe);
        catCafe.AgregarProducto(cafeGrano);

        var arequipeFresa = new ProductoDulce(
            nombre: "Arequipe de fresa",
            precio: 8000,
            stock: 20,
            sabor: "Fresa",
            costo: 4500
        );
        arequipeFresa.AsignarCategoria(catDulces);
        catDulces.AgregarProducto(arequipeFresa);

        var galleta = new ProductoDulce(
            nombre: "Galleta de café",
            precio: 3500,
            stock: 0,           // sin stock a propósito para probar filtro Inactivo
            sabor: "Café",
            costo: 1800
        );
        galleta.ActualizarEstado(EstadoProducto.Inactivo);
        galleta.AsignarCategoria(catGalletas);
        catGalletas.AgregarProducto(galleta);

        productoRepo.Add(cafe250);
        productoRepo.Add(cafeGrano);
        productoRepo.Add(arequipeFresa);
        productoRepo.Add(galleta);

        // Registrar entradas iniciales en Kardex
        inventarioRepo.Add(new Inventario(cafe250, TipoMovimiento.Entrada, OrigenMovimiento.AjusteManual,
            30, 9000, "Stock inicial", null));
        inventarioRepo.Add(new Inventario(cafeGrano, TipoMovimiento.Entrada, OrigenMovimiento.AjusteManual,
            5, 16000, "Stock inicial", null));
        inventarioRepo.Add(new Inventario(arequipeFresa, TipoMovimiento.Entrada, OrigenMovimiento.AjusteManual,
            20, 4500, "Stock inicial", null));

        // ── 3. USUARIOS ────────────────────────────────────────────
        var admin = new Usuario(
            nombre: "Admin Principal",
            email: "admin@cafe.com",
            password: "Admin123",
            rol: RolUsuario.Admin
        );

        var empleado = new Usuario(
            nombre: "Juan Empleado",
            email: "juan@cafe.com",
            password: "Empleado123",
            rol: RolUsuario.Empleado
        );

        usuarioRepo.Add(admin);
        usuarioRepo.Add(empleado);

        // ── 4. PROVEEDOR ───────────────────────────────────────────
        var proveedor = new Proveedor(
            nombre: "Café del Eje",
            telefono: "3001234567",
            email: "ventas@cafeeje.com",
            ciudad: "Pereira"
        );
        proveedorRepo.Add(proveedor);
    }
}