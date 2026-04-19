namespace ProyectoInventario.models
{
    public class DetalleVenta
    {
        private Producto producto;
        private Venta venta;
        private int cantidad;
        private decimal precioUnitario;

        public DetalleVenta( Producto producto, Venta venta, int cantidad)
        {
            this.producto = producto;
            this.venta = venta;
            this.cantidad = cantidad;
            this.precioUnitario = producto.Precio;
        }

        public Producto Producto
        {
            get { return producto; }
        }

        public Venta Venta
        {
            get { return venta; }
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