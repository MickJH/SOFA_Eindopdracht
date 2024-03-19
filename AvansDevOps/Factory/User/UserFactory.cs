using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Factory.User
{
    public class UserFactory
    {
        public static T CreateUser<T>() where T : User, new()
        {
            return new T();
        }
    }
}
