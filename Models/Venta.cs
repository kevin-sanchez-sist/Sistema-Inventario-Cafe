namespace ProyectoInventario.models
{
    public class Venta
    {
        public int Id {get; set;}
        private DateTime fecha;
        private EstadoVenta estadoVenta;
        private Empleado vendedor;
        private List<DetalleVenta> detalles;

        public Venta(int id, Empleado vendedor)
        {
            if (vendedor == null)
                throw new ArgumentException("La venta debe tener un vendedor");

            this.Id = id;
            this.vendedor = vendedor;
            this.fecha = DateTime.Now;
            this.estadoVenta = EstadoVenta.Pendiente;
            this.detalles = new List<DetalleVenta>();
        }

        public DateTime Fecha
        {
            get { return fecha; }
        }

        public EstadoVenta Estado
        {
            get { return estadoVenta; }
        }

        public Empleado Vendedor
        {
            get {return vendedor; }
        }

    }
}