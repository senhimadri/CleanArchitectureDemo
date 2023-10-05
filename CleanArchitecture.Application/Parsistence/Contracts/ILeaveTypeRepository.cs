using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Parsistence.Contracts;

public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
{
    Task ChangeApprovalStatus(LeaveType leaverequest, bool? approvalstatus);
}
