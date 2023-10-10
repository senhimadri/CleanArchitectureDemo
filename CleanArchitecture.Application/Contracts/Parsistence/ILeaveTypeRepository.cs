using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Parsistence;

public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
{
    Task ChangeApprovalStatus(LeaveType leaverequest, bool? approvalstatus);
}
