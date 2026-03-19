namespace ProyectoInventario.models
{
    public class ProductoDulce : Producto
    {
        private string sabor;

        public ProductoDulce(int id, string nombre, decimal precio, int stock, string sabor) 
            : base(id, nombre, precio, stock)
        {
            if (string.IsNullOrWhiteSpace(sabor))
                throw new ArgumentException("El sabor no puede estar vacío.");

            this.sabor = sabor;
        }

        public string Sabor
        {
            get { return sabor; }
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Sabor: {sabor}");
        }
    }
}