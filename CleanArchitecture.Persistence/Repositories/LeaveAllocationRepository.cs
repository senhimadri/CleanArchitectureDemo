using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly LeaveManagmentDbContext _dbContext;
    public LeaveAllocationRepository(LeaveManagmentDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task ChangeApprovalStatus(LeaveAllocation leaverequest, bool? approvalstatus)
    {
        throw new NotImplementedException();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsListWithDetailsAsync()
    {
        var leaveallocation = await _dbContext.LeaveAllocations
                    .Include(q => q.LeaveType)
                    .ToListAsync();
        return leaveallocation;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id)
    {
        var leaveallocation = await _dbContext.LeaveAllocations
             .Include(q => q.LeaveType)
             .FirstOrDefaultAsync(x => x.Id == id);
        return leaveallocation;
    }
}
