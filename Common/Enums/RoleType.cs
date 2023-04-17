﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    [Flags]
    public enum RoleType
    {
        Employee = 1,
        Manager = 2,
        Admin = 4,
    }
}
