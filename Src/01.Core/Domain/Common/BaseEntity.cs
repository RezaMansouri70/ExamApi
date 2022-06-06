﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.Common
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; private set; }
         
        public BaseEntity()
        {
            ModifiedDate = DateTime.Now;
        }
    }
}
