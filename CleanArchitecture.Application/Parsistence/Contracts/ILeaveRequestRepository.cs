using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Parsistence.Contracts;

public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id);
    Task<List<LeaveRequest>> GetLeaveRequestListWithDetailsAsync();

    Task ChangeApprovalStatus(LeaveRequest leaverequest,bool? approvalstatus);
}
