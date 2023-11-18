using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>,ILeaveRequestRepository
{
    private readonly LeaveManagmentDbContext _dbContext;
    public LeaveRequestRepository(LeaveManagmentDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaverequest, bool? approvalstatus)
    {
        leaverequest.Approved = approvalstatus;
        _dbContext.Entry(leaverequest).State= EntityState.Modified;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetailsAsync()
    {
        var leaverequest = await _dbContext.LeaveRequests
                            .Include(q=>q.LeaveType)
                            .ToListAsync();
        return leaverequest;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id)
    {
        var leaverequest = await _dbContext.LeaveRequests
                    .Include(q => q.LeaveType)
                    .FirstOrDefaultAsync(x=>x.Id==id);

        return leaverequest;
    }
}
