namespace ProyectoInventario.models
{
    public class DetalleOrdenCompra
    {
        private Producto producto;
        private int cantidad;
        private decimal costoUnitario;

        public DetalleOrdenCompra( Producto producto, int cantidad, decimal costo)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            this.costoUnitario = costo;
        }

        public Producto Producto
        {
            get { return producto; }
        }

        public int Cantidad
        {
            get { return cantidad; }
        }

        public decimal CostoUnitario
        {
            get { return costoUnitario; }
        }
    }
}