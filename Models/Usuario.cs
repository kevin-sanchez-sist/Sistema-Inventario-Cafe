namespace ProyectoInventario.models
{
    public class Usuario : BaseEntity
    {
        private string nombre;
        private string email;
        private string password;
        private RolUsuario rol;

        public Usuario(string nombre, string email, string password, RolUsuario rol)
        {
            this.nombre = nombre;
            this.email = email;
            this.password = password;
            this.rol = rol;
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Password
        {
            get { return password; }
        }

        public RolUsuario Rol
        {
            get { return rol; }
        }
    }
}