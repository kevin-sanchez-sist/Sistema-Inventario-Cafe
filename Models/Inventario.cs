namespace ProyectoInventario.models
{
    public class Inventario : BaseEntity
    {
        private Producto producto;
        private TipoMovimiento tipo;
        private OrigenMovimiento origen;
        private int cantidad;
        private decimal costoUnitario;
        private decimal costoTotal;
        private int saldoCantidad;
        private decimal saldoValor;
        private DateTime fecha;
        private string motivo;
        private Guid? ordenCompraId;

        public Inventario(Producto producto, TipoMovimiento tipo, OrigenMovimiento origen,
         int cantidad, decimal costoUnitario, string motivo, Guid? ordenCompraId = null)
        {
            this.producto = producto;
            this.tipo = tipo;
            this.origen = origen;
            this.cantidad = cantidad;
            this.costoUnitario = costoUnitario;
            this.costoTotal = costoUnitario * cantidad;
            this.fecha = DateTime.Now;
            this.motivo = motivo;
            this.ordenCompraId = ordenCompraId;

            this.saldoCantidad = tipo == TipoMovimiento.Entrada? producto.Stock + cantidad : producto.Stock - cantidad;

            this.saldoValor = saldoCantidad * producto.CostoPromedio;
        }

        public Producto Producto  
        { 
            get { return producto; } 
        }

        public TipoMovimiento Tipo      
        {
             get { return tipo; }
        }

        public OrigenMovimiento Origen  
        {
             get { return origen; } 
        }

        public int Cantidad             
        { 
            get { return cantidad; }
        }

        public decimal CostoUnitario    
        { 
            get { return costoUnitario; } 
        }

        public decimal CostoTotal       
        { 
            get { return costoTotal; } 
        }

        public int SaldoCantidad        
        {
             get { return saldoCantidad; }
        }

        public decimal SaldoValor       
        {
             get { return saldoValor; } 
        }
        public DateTime Fecha           
        {
             get { return fecha; } 
        }
        public string Motivo            
        {
             get { return motivo; } 
        }
        public Guid? OrdenCompraId      
        {
             get { return ordenCompraId; } 
        }
    }
}