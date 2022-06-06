using DataLayer.SqlServer.Common;
using DomainClass.UserExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SqlServer.Repositories
{

    public class UserRepository : IUserRepository
    {
        ApplicationContext _dbContext;
        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }



        public User GetByMobile(string mobile) => _dbContext.Users.FirstOrDefault(c => c.Mobile == mobile);

        public void Insert(User entity)
        {

            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
