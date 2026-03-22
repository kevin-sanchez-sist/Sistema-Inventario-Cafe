namespace ProyectoInventario.models
{
    public abstract class Producto
    {
        public Guid Id {get; private set;}
        private string nombre;
        private decimal precio;
        private int stock;
        private EstadoProducto estado;
        private Categoria? categoria;

        public Producto (string nombre, decimal precio, int stock)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
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

        protected void ActualizarPrecio(decimal nuevoPrecio)
        {
            precio = nuevoPrecio;
        }

        public void AsignarCategoria(Categoria categoria)
        {            
            this.categoria = categoria;
        }
    }
}