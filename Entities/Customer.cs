﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : IEntity
    {
        //public int CustomerId { get; set; }
        [Key]
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
