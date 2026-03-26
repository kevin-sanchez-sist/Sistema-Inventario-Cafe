namespace ProyectoInventario.models
{
    public class DetalleVenta
    {
        private Producto producto;
        private int cantidad;
        private decimal precioUnitario;

        public DetalleVenta( Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            this.precioUnitario = producto.Precio;
        }

        public Producto Producto
        {
            get { return producto; }
        }

        public int Cantidad
        {
            get { return cantidad; }
        }

        public decimal PrecioUnitario
        {
            get { return precioUnitario; }
        }

        public decimal Subtotal
        {
            get { return precioUnitario * cantidad; }
        }
    }
}