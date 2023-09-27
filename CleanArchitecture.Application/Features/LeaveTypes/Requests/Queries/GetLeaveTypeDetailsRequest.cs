﻿using CleanArchitecture.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveTypeDetailsRequest : IRequest<LeaveTypeDTO>
{
    public int Id { get; set; }
}
