namespace ProyectoInventario.models
{
    public class Inventario
    {
        public Guid Id { get; private set;}
        private Producto producto;
        private TipoMovimiento tipo;
        private int cantidad;
        private DateTime fecha;
        private string motivo;

        public Inventario(Producto producto, TipoMovimiento tipo, int cantidad, string motivo)
        {
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
    }
}