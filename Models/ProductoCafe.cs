namespace ProyectoInventario.models
{
    public class ProductoCafe : Producto
    {
        private string variante;
        private bool esMolido;

        public ProductoCafe(string nombre, decimal precio, int stock, string variante, bool esMolido, decimal costo) 
            : base(nombre, precio, stock, costo)
        {
            this.variante = variante;
            this.esMolido = esMolido;
        }

        public string Variante
        {
            get { return variante; }
        }

        public bool EsMolido
        {
            get { return esMolido; }
        }
    }
}