using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Parsistence;

public interface IUnitofWork
{
    ILeaveAllocationRepository LeaveAllocationRepository { get; }
    ILeaveRequestRepository LeaveRequestRepository { get; }
    ILeaveTypeRepository LeaveTypeRepository { get; }

    Task Save();
}
