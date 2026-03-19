using System.Data;

namespace ProyectoInventario.models
{
    public class Categoria
    {
        private int id;
        private string nombre;

        private List <Producto> productos;

        public Categoria(string nombre, int id)
        {
             if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");

            this.id = id;
            this.nombre = nombre;
            this.productos = new List<Producto>();
        }

        public int Id
        {
            get { return id; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public List<Producto> Productos
        {
            get { return productos; }
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public int ContarProductosActivos()
        {
            int count = 0;
            foreach (var p in productos)
            {
                if (p.Estado == EstadoProducto.Activo)
                    count ++;
            }

            return count;
        }

    }
}