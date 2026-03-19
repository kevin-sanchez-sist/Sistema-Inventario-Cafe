namespace ProyectoInventario.models
{
    public class ProductoCafe : Producto
    {
        private string variante;
        private bool esMolido;

        public ProductoCafe(int id, string nombre, decimal precio, int stock, string variante, bool esMolido) 
            : base(id, nombre, precio, stock)
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

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Variante: {variante}");
            Console.WriteLine($"{(esMolido ? "Es café molido" : "No es café molido")}");
        }
    }
}