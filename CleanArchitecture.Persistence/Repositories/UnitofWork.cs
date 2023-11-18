using CleanArchitecture.Application.Contracts.Parsistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories;

public class UnitofWork : IUnitofWork
{

    private readonly LeaveManagmentDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private  ILeaveAllocationRepository _leaveAllocationRepository;
    private  ILeaveRequestRepository _leaveRequestRepository;
    private  ILeaveTypeRepository _leaveTypeRepository;

    public UnitofWork(LeaveManagmentDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context=context;
        _httpContextAccessor=httpContextAccessor;
    }

    public ILeaveAllocationRepository LeaveAllocationRepository =>
            _leaveAllocationRepository ??= new LeaveAllocationRepository(_context);

    public ILeaveRequestRepository LeaveRequestRepository => 
            _leaveRequestRepository ??= new LeaveRequestRepository(_context);

    public ILeaveTypeRepository LeaveTypeRepository =>
            _leaveTypeRepository ??= new LeaveTypeRepository(_context);


    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
