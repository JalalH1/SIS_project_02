namespace Project_Info_Jalal_Harb.Models
{
    public interface IUserRepository
    {
        void createUser(User user);
        User? getUser(int userId);
        bool userSignIn(string email, string password);
        List<User> getAllUsers();
        void updateUser(User user);
        void UserDelete(int Id);
    }
}
