using Microsoft.EntityFrameworkCore;

namespace Project_Info_Jalal_Harb.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;

        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void createUser(User user)
        {
            user.Password = HashString(user.Password);
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
        }

        public User? getUser(int userId)
        {
            return _dbContext.users.Where(x => x.Id == userId).FirstOrDefault();
        }
        
        public List<User> getAllUsers()
        {
            return _dbContext.users.ToList();
        }

        public void updateUser(User user)
        {
            _dbContext.users.Update(user);
            _dbContext.SaveChanges();
        }
        
        public void UserDelete(int Id)
        {
            _dbContext.users.Where(user => user.Id == Id).ExecuteDelete();
            _dbContext.SaveChanges();
        }

        public bool userSignIn(string email, string password)
        {
            return _dbContext.users.Where(x => x.Email == email && x.Password == HashString(password)).Any();
        }

        string HashString(string text)
        {
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
    }
}
