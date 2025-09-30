using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace ProjetoMongoDB.Models
{
    [CollectionName("Roles")]
    public class ApplicationRole:MongoIdentityRole
    {

    }
}
