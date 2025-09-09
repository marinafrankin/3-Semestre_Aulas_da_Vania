using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace ProjetoMongoDB.Models
{
    [CollectionName("User")]// definição do nome da coleção no MongoDb
    public class ApplicationUser:MongoIdentityUser
    {
        public string NomeCompleto { get; set; }
    }
}
