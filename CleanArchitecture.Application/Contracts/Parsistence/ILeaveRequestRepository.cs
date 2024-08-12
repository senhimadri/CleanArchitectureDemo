using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Parsistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id);
    Task<List<LeaveRequest>> GetLeaveRequestListWithDetailsAsync();

    Task ChangeApprovalStatus(LeaveRequest leaverequest, bool? approvalstatus);
}
