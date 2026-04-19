namespace ProyectoInventario.models
{
    public abstract class Producto : BaseEntity
    {
        private string nombre;
        private decimal precio;
        private int stock;
        private EstadoProducto estado;
        private Categoria? categoria;
        private decimal costoPromedio;

        public Producto (string nombre, decimal precio, int stock, decimal costo)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.costoPromedio = costo;
            this.estado = EstadoProducto.Activo;  
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public decimal Precio
        {
            get { return precio; }
            protected set { precio = value;}
        }

        public int Stock
        {
            get { return stock; }
            protected set { stock = value;}
        }

        public EstadoProducto Estado
        {
            get { return estado; }
        }

        public Categoria? Categoria
        {
            get { return categoria; }
        }

        public decimal CostoPromedio
        {
            get { return costoPromedio; }
        }

        public void AgregarStock(int cantidad)
        {
            stock += cantidad;
        }

        public bool DescontarStock(int cantidad)
        {
            if (stock < cantidad || cantidad <= 0)
                return false;
            
            stock -= cantidad;
            return true;
        }

        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            precio = nuevoPrecio;
        }

        public void ActualizarCostoPromedio(int cantidadEntrante, decimal costoNuevo)
        {
            if (stock == 0)
            {
                costoPromedio = costoNuevo;
                return;
            }
            costoPromedio = ((stock * costoPromedio) + (cantidadEntrante * costoNuevo)) / (stock + cantidadEntrante);
        }

        public void AsignarCategoria(Categoria categoria)
        {            
            this.categoria = categoria;
        }

        public void ActualizarEstado(EstadoProducto nuevoEstado)
        {
            this.estado = nuevoEstado;
        }
    }
}