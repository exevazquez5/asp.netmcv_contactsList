using System.Data.SqlClient;

namespace asp_practica1._1.Datos
{
    public class Conexion
    {
        public string cadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            cadenaSQL = configuration.GetConnectionString("CadenaSQL");
        }
    }
}
