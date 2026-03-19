namespace ProyectoInventario.models
{
    public class DetalleVenta
    {
        public int Id { get; set;}
        private Producto producto;
        private int cantidad;
        private decimal precioUnitario;

        public DetalleVenta(int id, Producto producto, int cantidad)
        {
            if (producto == null)
                throw new ArgumentException("El producto no puede ser nulo.");
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            this.Id = id;
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

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {producto.Nombre}");
            Console.WriteLine($"Cantidad: {cantidad}");
            Console.WriteLine($"Precio unitario: {precioUnitario}");
            Console.WriteLine($"Subtotal: {Subtotal}");
        }
    }
}