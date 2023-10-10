using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType> ,ILeaveTypeRepository
{
    private readonly LeaveManagmentDbContext _dbContext;
    public LeaveTypeRepository(LeaveManagmentDbContext dbContext):base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task ChangeApprovalStatus(LeaveType leaverequest, bool? approvalstatus)
    {
        throw new NotImplementedException();
    }
}
