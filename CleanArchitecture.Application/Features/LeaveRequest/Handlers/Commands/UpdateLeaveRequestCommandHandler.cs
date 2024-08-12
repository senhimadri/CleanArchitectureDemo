using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveRequest.Validator;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    //private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(IUnitofWork unitofWork, ILeaveTypeRepository LeaveTypeRepository, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _leaveTypeRepository = LeaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {

        var leaverequest = await _unitofWork.LeaveRequestRepository.GetAsync(request.RequestId);

        if (request.LeaveRequestDTO is not null)
        {
            var validator = new UpdateLeaveRequestDTOValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            _mapper.Map(request.LeaveRequestDTO, leaverequest);
            await _unitofWork.LeaveRequestRepository.UpdateAsync(leaverequest);
        }
        else if (request.ChangeLeaveRequestApprovalDTO is not null)
        {
            await _unitofWork.LeaveRequestRepository.ChangeApprovalStatus(leaverequest, request.ChangeLeaveRequestApprovalDTO.IsApproved);
            await _unitofWork.Save();
        }

        return Unit.Value;
    }
}
