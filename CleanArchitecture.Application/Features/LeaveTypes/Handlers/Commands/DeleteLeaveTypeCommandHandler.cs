using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Commands;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leavetype =await _leaveTypeRepository.GetAsync(request.id);

        if (leavetype is null)
            throw new NotFoundException(name:nameof(LeaveType),key: request.id);

        await _leaveTypeRepository.DeleteAsync(request.id);

        return Unit.Value;
    }
}
