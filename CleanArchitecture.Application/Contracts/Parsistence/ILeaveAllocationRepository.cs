using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Parsistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationsListWithDetailsAsync();
    Task ChangeApprovalStatus(LeaveAllocation leaverequest, bool? approvalstatus);
}
