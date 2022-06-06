using DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.UserExam
{
    public interface IUserRepository 
    {
        void Insert(User entity);
        User GetByMobile(string mobile);

    }
}
