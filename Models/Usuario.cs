namespace ProyectoInventario.models
{
    public abstract class Usuario
    {
        public int Id {get; set;}
        private string nombre;
        private string email;
        private string password;

        public Usuario(string nombre, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña no puede estar vacía.");

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

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Email: {email}");
        }
    }
}