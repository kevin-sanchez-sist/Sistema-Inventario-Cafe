namespace ProyectoInventario.models
{
    public abstract class Producto
    {
        private int id;
        private string nombre;
        private decimal precio;
        private int stock;
        private EstadoProducto estado;
        private Categoria? categoria;

        public Producto (int id, string nombre, decimal precio, int stock)
        {
            if (String.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del producto no puede estar vacio.");
            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.");

            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.estado = EstadoProducto.Activo;
        }

        public int Id
        {
            get { return id; }
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
            if (cantidad <=0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

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
            if (nuevoPrecio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.");

            precio = nuevoPrecio;
        }

        public void AsignarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentException("La categoría no puede ser nula.");
            
            this.categoria = categoria;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Precio: {precio}");
            Console.WriteLine($"Stock: {stock}");
            Console.WriteLine($"Estado: {estado}");
        }
    }
}