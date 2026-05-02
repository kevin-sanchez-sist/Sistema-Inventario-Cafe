using Mapster;
using ProyectoInventario.models;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        // ── PRODUCTO ───────────────────────────────────────────────
        TypeAdapterConfig<Producto, ProductoResponseDto>.NewConfig()
            .Map(dest => dest.CategoriaNombre, src => src.Categoria != null ? src.Categoria.Nombre : null)
            .Map(dest => dest.Tipo, src => src is ProductoCafe ? TipoProducto.ProductoCafe : TipoProducto.ProductoDulce)
            .Map(dest => dest.Variante, src => src is ProductoCafe ? ((ProductoCafe)src).Variante : null)
            .Map(dest => dest.EsMolido, src => src is ProductoCafe ? ((ProductoCafe)src).EsMolido : (bool?)null)
            .Map(dest => dest.Sabor, src => src is ProductoDulce ? ((ProductoDulce)src).Sabor : null);

        // ── CATEGORIA ──────────────────────────────────────────────
        TypeAdapterConfig<Categoria, CategoriaResponseDto>.NewConfig()
            .Map(dest => dest.ProductosActivos, src => src.ContarProductosActivos());

        TypeAdapterConfig<Categoria, CategoriaDetalleResponseDto>.NewConfig()
            .Map(dest => dest.Productos, src => src.Productos.Adapt<List<ProductoResponseDto>>());

        // ── PROVEEDOR ──────────────────────────────────────────────
        // Todas las propiedades coinciden, Mapster lo resuelve solo.

        // ── USUARIO ────────────────────────────────────────────────
        // Nombre, Email, Rol coinciden, Mapster lo resuelve solo.

        // ── ORDEN DE COMPRA ────────────────────────────────────────
        TypeAdapterConfig<OrdenCompra, OrdenCompraResponseDto>.NewConfig()
            .Map(dest => dest.NombreProveedor, src => src.Proveedor.Nombre)
            .Map(dest => dest.Total, src => src.CalcularTotal())
            .Map(dest => dest.Items, src => src.Detalles.Adapt<List<DetalleOrdenCompraResponseDto>>());

        TypeAdapterConfig<DetalleOrdenCompra, DetalleOrdenCompraResponseDto>.NewConfig()
            .Map(dest => dest.NombreProducto, src => src.Producto.Nombre)
            .Map(dest => dest.Subtotal, src => src.CostoUnitario * src.Cantidad);

        // ── VENTA ──────────────────────────────────────────────────
        TypeAdapterConfig<Venta, VentaResponseDto>.NewConfig()
            .Map(dest => dest.Vendedor, src => src.Vendedor.Nombre)
            .Map(dest => dest.Estado, src => src.Estado)
            .Map(dest => dest.Total, src => src.Total)
            .Map(dest => dest.Items, src => src.Detalles.Adapt<List<DetalleVentaResponseDto>>());

        TypeAdapterConfig<DetalleVenta, DetalleVentaResponseDto>.NewConfig()
            .Map(dest => dest.VentaId, src => src.Venta.Id)
            .Map(dest => dest.FechaVenta, src => src.Venta.Fecha)
            .Map(dest => dest.NombreProducto, src => src.Producto.Nombre)
            .Map(dest => dest.Subtotal, src => src.Subtotal);

        // ── INVENTARIO ─────────────────────────────────────────────
        TypeAdapterConfig<Inventario, InventarioResponseDto>.NewConfig()
            .Map(dest => dest.NombreProducto, src => src.Producto.Nombre);
    }
}