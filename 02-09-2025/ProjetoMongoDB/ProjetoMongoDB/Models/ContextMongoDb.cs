using MongoDB.Driver;

namespace ProjetoMongoDB.Models
{
    public class ContextMongoDb
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool Isssl {  get; set; }
        public IMongoDatabase _database { get; }

        public ContextMongoDb()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (Isssl)
                {
                    settings.SslSettings = new SslSettings
                    {
                        EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                    };
                }

                var mongoclient = new MongoClient(settings);
                _database = mongoclient.GetDatabase(DatabaseName);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível entrar no MongoDb");
            }
        } // Fim do constrututor

       
    } // Fim da classe
}
