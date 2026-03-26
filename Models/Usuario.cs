namespace ProyectoInventario.models
{
    public abstract class Usuario : BaseEntity
    {
        private string nombre;
        private string email;
        private string password;

        public Usuario(string nombre, string email, string password)
        {
            this.nombre = nombre;
            this.email = email;
            this.password = password;
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public string Email
        {
            get { return email; }
        }
    }
}