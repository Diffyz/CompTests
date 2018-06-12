using Authorization.Interface;
using DateBaseProject;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Services
{
    public class UserServices : IworkDBUser
    {
        public bool CheckUser(User user)
        {
            using (SimpleContext context = new SimpleContext())
            {
                User userRow = context.users.SingleOrDefault(p => p.login == user.login && p.password == user.password);

                if (userRow != null)
                {
                    return true;
                }
                
            }
            return false;
        }
        public async Task<bool> Add(User user)
        {
            using(SimpleContext context = new SimpleContext())
            {
                try
                {
                    User userRow = context.users.SingleOrDefault(p => p.login == user.login && p.password == user.password);

                    if (userRow == null)
                    {
                        context.users.Add(user);
                        await context.SaveChangesAsync();
                        return true;
                    }
                }
                catch { }
            }
            return false;
        }
        
        public async void Remove(User user)
        {
            try
            {
                using (SimpleContext context = new SimpleContext())
                {

                    User userRow = context.users.SingleOrDefault(p => p.login == user.login && p.password == user.password);

                    if (userRow != null)
                    {
                        context.users.Remove(user);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch { }
        }
    }
}