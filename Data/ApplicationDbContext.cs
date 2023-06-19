using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Data;
using WebApplication1.Models;

public class ApplicationDbContext
{
    private readonly IMongoDatabase _database;

    public ApplicationDbContext(IOptions<AppSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("users");
    // Add other collections as needed
}
