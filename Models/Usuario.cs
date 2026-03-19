namespace ProyectoInventario.models
{
    public abstract class Usuario
    {
        private int id;
        private string nombre;
        private string email;
        private string password;

        public Usuario(string nombre, string email, string password, int id)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña no puede estar vacía.");

            this.id = id;
            this.nombre = nombre;
            this.email = email;
            this.password = password;
        }

        public int Id
        {
            get { return id; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public string Email
        {
            get { return email; }
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Email: {email}");
        }
    }
}