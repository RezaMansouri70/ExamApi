using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Models.UserExam;

namespace ApplicationServices.Services.UserExam
{
    public interface IUserExamService
    {
           
        DomainClass.UserExam.UserExam MakeExam(AddUserExamDto inputExam,string? currentUser);
        List<UserExamItem> GetExam(int pageNumber , int pageSize, string? currentUser);
        DomainClass.UserExam.UserExam Edit(EditUserExamDto inputExam, string? currentUser);
        bool Delete(long ID, string? currentUser);


    }
}
