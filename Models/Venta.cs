namespace ProyectoInventario.models
{
    public class Venta : BaseEntity
    {
        private DateTime fecha;
        private EstadoVenta estadoVenta;
        private Usuario vendedor;
        private List<DetalleVenta> detalles;

        public Venta(Usuario vendedor)
        {
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

        public Usuario Vendedor
        {
            get {return vendedor; }
        }

        public List<DetalleVenta> Detalles
        {
            get { return detalles; }
        }

        public void AgregarDetalle(DetalleVenta detalle)
        {
            detalles.Add(detalle);
        }

        public void Completar()
        {
            estadoVenta = EstadoVenta.Completada;
        }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var d in detalles)
                    total += d.Subtotal;
                return total;
            }
        }

    }
}