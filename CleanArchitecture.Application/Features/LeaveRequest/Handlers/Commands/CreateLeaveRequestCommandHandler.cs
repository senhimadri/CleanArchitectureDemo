using CleanArchitecture.Domain;
using AutoMapper;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.DTOs.LeaveType.Validators;
using CleanArchitecture.Application.DTOs.LeaveRequest.Validator;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly ILeaveRequestRepository _LeaveRequestRepository;
    private readonly ILeaveTypeRepository _LeaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository LeaveRequestRepository,ILeaveTypeRepository LeaveTypeRepository, IMapper mapper)
    {
        _LeaveRequestRepository = LeaveRequestRepository;
        _LeaveTypeRepository = LeaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestDTOValidator(_LeaveTypeRepository);

        var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

        if (!validationResult.IsValid)
            throw new Exception();

        var leaverequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDTO);
        leaverequest = await _repository.AddAsync(leaverequest);
        return leaverequest.Id;
    }
}
