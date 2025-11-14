namespace _1_EcommerceMVC_EFCore.Models
{
    public class AppSettings
    {
        public string ApiUrl { get; set; }
        public string LogLevel { get; set; }
    }
    public class Configuracao
    {
        // Classe de configuração utilizada para pegar as informações do appsettings
        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
