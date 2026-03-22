namespace ProyectoInventario.models
{
    public class ProductoDulce : Producto
    {
        private string sabor;

        public ProductoDulce(string nombre, decimal precio, int stock, string sabor) 
            : base(nombre, precio, stock)
        {
            this.sabor = sabor;
        }

        public string Sabor
        {
            get { return sabor; }
        }
    }
}