using DateBaseProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Interface
{
    public interface IworkDBUser
    {
        Task<bool> Add(User user);
        void Remove(User user);
    }
}
