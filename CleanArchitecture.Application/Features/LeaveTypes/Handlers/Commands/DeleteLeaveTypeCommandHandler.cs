using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Commands;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand,Unit>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public DeleteLeaveTypeCommandHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leavetype =await _unitofWork.LeaveTypeRepository.GetAsync(request.id);

        if (leavetype is null)
            throw new NotFoundException(name:nameof(LeaveType),key: request.id);

        await _unitofWork.LeaveTypeRepository.DeleteAsync(leavetype);
        await _unitofWork.Save();

        return Unit.Value;
    }
}
