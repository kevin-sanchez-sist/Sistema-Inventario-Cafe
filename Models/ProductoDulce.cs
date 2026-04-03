namespace ProyectoInventario.models
{
    public class ProductoDulce : Producto
    {
        private string sabor;

        public ProductoDulce(string nombre, decimal precio, int stock, string sabor, decimal costo) 
            : base(nombre, precio, stock, costo)
        {
            this.sabor = sabor;
        }

        public string Sabor
        {
            get { return sabor; }
        }
    }
}