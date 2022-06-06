using DataLayer.SqlServer.Common;
using DomainClass.UserExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SqlServer.Repositories
{

    public class UserExamRepository : EfRepository<UserExam>, IUserExamRepository
    {
        public UserExamRepository(ApplicationContext DbContext) : base(DbContext)
        {
        }

   
    }
}
