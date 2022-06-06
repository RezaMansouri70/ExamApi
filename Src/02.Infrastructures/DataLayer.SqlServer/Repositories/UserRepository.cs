using DataLayer.SqlServer.Common;
using DomainClass.UserExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SqlServer.Repositories
{

    public class UserRepository : EfRepository<User>, IUserRepository
    {
        ApplicationContext _dbContext;
        public UserRepository(ApplicationContext DbContext) : base(DbContext)
        {
            _dbContext = DbContext;
        }
        public User GetByMobile(string mobile) => _dbContext.Users.FirstOrDefault(c => c.Mobile == mobile);


    }

}
