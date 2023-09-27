using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Parsistence.Contracts;

public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id);
}
