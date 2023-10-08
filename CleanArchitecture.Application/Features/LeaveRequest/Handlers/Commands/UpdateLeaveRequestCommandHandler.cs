using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveRequest.Validator;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _LeaveRequestRepository;
    private readonly ILeaveTypeRepository _LeaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository LeaveRequestRepository,ILeaveTypeRepository LeaveTypeRepository, IMapper mapper)
    {
        _LeaveRequestRepository = LeaveRequestRepository;
        _LeaveTypeRepository = LeaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {

        var leaverequest = await _LeaveRequestRepository.GetAsync(request.RequestId);

        if (request.LeaveRequestDTO is not null)
        {
            var validator = new UpdateLeaveRequestDTOValidator(_LeaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            _mapper.Map(request.LeaveRequestDTO, leaverequest);
            await _LeaveRequestRepository.UpdateAsync(leaverequest);
        }
        else if(request.ChangeLeaveRequestApprovalDTO is not null)
        {
            await _LeaveRequestRepository.ChangeApprovalStatus(leaverequest, request.ChangeLeaveRequestApprovalDTO.IsApproved);
        }

        return Unit.Value;
    }
}
