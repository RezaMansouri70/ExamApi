using DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.UserExam
{
    public class User : BaseEntity
    {
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
