using MongoDB.Driver;
using MongoFramework;
using MongoFramework.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
        private ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<User?> GetUser(string id)
        {
            return await _dbContext.Users.Find(u => u.Id == id).FirstOrDefaultAsync();

        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.Find(u => true).ToListAsync();
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.InsertOneAsync(user);
        }

        public async Task UpdateUser(string id, User user)
        {
            await _dbContext.Users.ReplaceOneAsync(u => u.Id == id, user);
        }
        public async Task<bool> DeleteUser(string id)

        {
            var user = await _dbContext.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
              await  _dbContext.Users.DeleteOneAsync(u => u.Id == id);

                return true;
            }
            else
            {
                return false;
            }
        }






    }
}
