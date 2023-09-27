using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Parsistence.Contracts;

public interface ILeaveAllocationRepository:IGenericRepository<ILeaveAllocationRepository>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
}
