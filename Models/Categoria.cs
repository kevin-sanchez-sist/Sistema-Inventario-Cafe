using System.Data;

namespace ProyectoInventario.models
{
    public class Categoria : BaseEntity
    {
        private string nombre;

        private List <Producto> productos;

        public Categoria(string nombre)
        {
            this.nombre = nombre;
            this.productos = new List<Producto>();
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