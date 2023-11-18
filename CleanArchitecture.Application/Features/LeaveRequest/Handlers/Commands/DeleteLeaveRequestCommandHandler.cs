using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Commands;

public class DeleteLeaveRequestCommandHandler :IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    //private readonly ILeaveRequestRepository _repository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public DeleteLeaveRequestCommandHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaverequest = await _unitofWork.LeaveRequestRepository.GetAsync(request.Id);
        if (leaverequest is null)
            throw new NotFoundException(name: nameof(Domain.LeaveRequest), key: request.Id);

        await _unitofWork.LeaveRequestRepository.DeleteAsync(leaverequest);
        await _unitofWork.Save();

        return Unit.Value;
    }
}
