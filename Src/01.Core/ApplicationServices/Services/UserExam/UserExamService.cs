using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Models.UserExam;
using ApplicationServices.Services.UserService;
using DomainClass.UserExam;

namespace ApplicationServices.Services.UserExam
{
    public class UserExamService : IUserExamService
    {
        private readonly IUserExamRepository _examRepository;
        private readonly IUserService _userService;


        public UserExamService(IUserExamRepository examRepository, IUserService userService)
        {
            _examRepository = examRepository;
            _userService = userService;
        }

        public bool Delete(long ID, string? currentUser)
        {
            var exam = _examRepository.Get(Convert.ToInt32(ID));
            var user = _userService.GetUserByMobile(currentUser);

            if (exam.User.Id.ToString().ToLower() == user.Id.ToString().ToLower())
            {
                exam.IsDeleted = true;
                _examRepository.Update(exam);
                _examRepository.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException();

            }
            return true;
        }

        public DomainClass.UserExam.UserExam Edit(EditUserExamDto inputExam, string? currentUser)
        {
            var exam = _examRepository.Get(Convert.ToInt32(inputExam.Id));
            var user = _userService.GetUserByMobile(currentUser);

            if (exam.User.Id.ToString().ToLower() == user.Id.ToString().ToLower())
            {

                exam.Name = inputExam.Name;
                exam.EndDate = inputExam.EndDate;
                exam.StartDate = inputExam.StartDate;
                _examRepository.Update(exam);
                _examRepository.SaveChanges();

            }
            else
            {
                throw new UnauthorizedAccessException();

            }
            return exam;
        }


        public List<UserExamItem> GetExam(int pageNumber, int pageSize, string? currentUser)
        {
            var user = _userService.GetUserByMobile(currentUser);
            return _examRepository.GetQueryable().Where(u => u.User.Id.ToString().ToLower() == user.Id.ToString().ToLower()).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(o =>
                new UserExamItem
                {
                    Id = o.Id,
                    Name = o.Name,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate
                }).ToList();
        }

        public DomainClass.UserExam.UserExam MakeExam(AddUserExamDto inputExam, string? currentUser)
        {

            DomainClass.UserExam.UserExam itemForAdd = new DomainClass.UserExam.UserExam()
            {
                Name = inputExam.Name,
                User = _userService.GetUserByMobile(currentUser),
                StartDate = inputExam.StartDate,
                EndDate = inputExam.EndDate,
                CreatedDate = DateTime.Now,
            };
            _examRepository.Insert(itemForAdd);
            _examRepository.SaveChanges();
            return itemForAdd;
        }

    }


}
