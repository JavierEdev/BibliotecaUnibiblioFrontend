namespace BibliotecaUnibiblioMVC.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion()
        {

            var currentDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(currentDirectory);

            var builder = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;

        }
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
