// Ignore Spelling: App

using Microsoft.EntityFrameworkCore;
using MongoFramework;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : MongoDbContext
    {

        public AppDbContext(IMongoDbConnection connection) : base(connection) { }

        public MongoDbSet<User> Users { get; set; }
        public MongoDbSet<Review> Reviews { get; set; }







    }
}
