namespace ProyectoInventario.models
{
    public enum EstadoProducto
    {
        Inactivo,
        Activo
    }

    public enum TipoProducto
    {
        ProductoCafe,
        ProductoDulce
    }

    public enum RolUsuario
    {
        Admin = 1,
        Empleado = 2
    }

    public enum EstadoVenta
    {
        Pendiente = 1,
        Completada = 2,
        Cancelada = 3
    }

    public enum TipoMovimiento
    {
        Entrada = 1,
        Salida = 2
    }
}