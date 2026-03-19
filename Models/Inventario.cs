namespace ProyectoInventario.models
{
    public class Inventario
    {
        public int Id { get; set;}
        private Producto producto;
        private TipoMovimiento tipo;
        private int cantidad;
        private DateTime fecha;
        private string motivo;

        public Inventario(int id, Producto producto, TipoMovimiento tipo, int cantidad, string motivo)
        {
            if (producto == null)
                throw new ArgumentException("El producto no puede ser nulo.");
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("El motivo no puede estar vacio.");

            this.Id = id;
            this.producto = producto;
            this.tipo = tipo;
            this.cantidad = cantidad;
            this.fecha = DateTime.Now;
            this.motivo = motivo;
        }

        public Producto Producto
        {
            get { return producto; }
        }

        public TipoMovimiento Tipo
        {
            get { return tipo; }
        }

        public int Cantidad
        {
            get { return cantidad; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
        }

        public string Motivo
        {
            get { return motivo; }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {producto.Nombre}");
            Console.WriteLine($"Tipo: {tipo}");
            Console.WriteLine($"Cantidad: {cantidad}");
            Console.WriteLine($"Fecha: {fecha}");
            Console.WriteLine($"Motivo: {motivo}");
        }
    }
}