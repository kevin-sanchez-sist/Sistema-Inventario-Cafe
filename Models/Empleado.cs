namespace ProyectoInventario.models
{
    public class Empleado : Usuario
    {
        public RolUsuario Rol { get; } = RolUsuario.Vendedor;

        public Empleado(string nombre, string email, string password)
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