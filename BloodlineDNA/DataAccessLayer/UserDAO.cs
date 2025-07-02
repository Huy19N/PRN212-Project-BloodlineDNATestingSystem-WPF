using BusinessObjects;

namespace DataAccessLayer;

public class UserDAO
{
    public List<User> GetAllUsers()
    {
        using var context = new GeneCareContext();
        return context.Users.ToList();
    }
    public bool CreateUser(User user)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (user == null)
            {
                return false;
            }

            context.Users.Add(new User
            {
                RoleId = user.RoleId,
                Email = user.Email,
                Password = user.Password
            });

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool UpdateUser(User user)
    {
        using var context = new GeneCareContext();
        if (user == null)
        {
            return false;
        }
        var existingUser = context.Users.Find(user.UserId);
        if (existingUser == null)
        {
            return false;
        }

        using var transaction = context.Database.BeginTransaction();
        try
        {
            existingUser.RoleId = user.RoleId;
            existingUser.FullName = user.FullName;
            existingUser.IdentifyId = user.IdentifyId;
            existingUser.Address = user.Address;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            existingUser.Password = user.Password;


            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool DeleteUserById(int id)
    {
        using var context = new GeneCareContext();
        var user = context.Users.Find(id);
        if (user == null) return false;

        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Users.Remove(user);

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}
