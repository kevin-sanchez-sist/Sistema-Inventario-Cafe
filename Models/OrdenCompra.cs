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

        public List<DetalleOrdenCompra> Detalles
        {
            get { return detalles; }
        }

        public void AgregarDetalle(DetalleOrdenCompra detalle)
        {
            detalles.Add(detalle);
        }

        public bool Recibir()
        {
            if (estado != EstadoOrden.Pendiente) return false;
            estado = EstadoOrden.Recibida;
            return true;
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var d in detalles)
                total += d.CostoUnitario * d.Cantidad;
            return total;
        }
    }
}