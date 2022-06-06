using Moq;
using Xunit;
using ApplicationServices.Models.UserExam;
using ApplicationServices.Services.UserExam;
using Api.Controllers;
using DomainClass.UserExam;
using System;
using ApplicationServices.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest
{
    public class Test
    {

        [Fact]
        public void UserExam_Test()
        {
            //Areange
            var moq = new Mock<IUserExamService>();
            ExamController controller = new ExamController(moq.Object);

            AddUserExamDto exam = new AddUserExamDto()
            {
                Name = "Exam1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
            };


            //Act
            var result = controller.Post(exam);


            //Assert
            Assert.IsType<CreatedResult>(result);


        }
    }
}