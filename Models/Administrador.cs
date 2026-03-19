namespace ProyectoInventario.models
{
    public class Administrador : Usuario
    {
        public RolUsuario Rol { get; } = RolUsuario.Admin;

        public Administrador(string nombre, string email, string password)
             : base(nombre, email, password)
        {
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Rol: {Rol}");
        }

    }
}