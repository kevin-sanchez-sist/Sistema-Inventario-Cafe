namespace ProyectoInventario.models
{
    public abstract class Producto
    {
        public int Id {get; set;}
        public required string Nombre {get; set;}
        private decimal precio;
        private int stock;
        private EstadoProducto estado;

        public Producto (int id, string nombre, decimal precio, int stock)
        {
            if (String.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del producto no puede estar vacio.");
            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.");

            this.Id = id;
            this.Nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.estado = EstadoProducto.Activo;
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

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Precio: {precio}");
            Console.WriteLine($"Stock: {stock}");
            Console.WriteLine($"Estado: {estado}");
        }
    }
}