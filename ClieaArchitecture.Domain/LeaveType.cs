﻿using ClieaArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClieaArchitecture.Domain;

public class LeaveType: BaseDomainEntity
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
