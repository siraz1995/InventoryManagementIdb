﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Authentication
{
    public class Role
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
