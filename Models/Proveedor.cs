namespace ProyectoInventario.models
{
    public class Proveedor : BaseEntity
    {
        private string nombre;
        private string telefono;
        private string email;
        private string ciudad;

        public Proveedor(string nombre, string telefono, string email, string ciudad)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.email = email;
            this.ciudad = ciudad;
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public string Telefono
        {
            get { return telefono; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Ciudad
        {
            get { return ciudad; }
        }

        public void ActualizarContacto(string? telefono, string? email, string? ciudad)
        {
            if (telefono != null) this.telefono = telefono;
            if (email != null) this.email = email;
            if (ciudad != null) this.ciudad = ciudad;
        }
    }
}