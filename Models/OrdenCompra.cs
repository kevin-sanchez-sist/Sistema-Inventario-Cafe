namespace ProyectoInventario.models
{
    public class OrdenCompra : BaseEntity
    {
        private DateTime fecha;
        private EstadoOrden estado;
        private Proveedor proveedor;
        private List<DetalleOrdenCompra> detalles;

        public OrdenCompra(Proveedor proveedor)
        {
            this.fecha = DateTime.Now;
            this.estado = EstadoOrden.Pendiente;
            this.proveedor = proveedor;
            this.detalles = new List<DetalleOrdenCompra>();
        }

         public DateTime Fecha
        {
            get { return fecha; }
        }

        public EstadoOrden Estado
        {
            get { return estado; }
        }

        public Proveedor Proveedor
        {
            get { return proveedor; }
        }
    }
}