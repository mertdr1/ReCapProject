﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Color: IEntity
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
    }
}
