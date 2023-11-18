using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveType.Validators;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Commands;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {

        var validator = new UpdateLeaveTypeDTOValidator();

        var validationResult = await validator.ValidateAsync(request.LeaveTypeDTO);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var leavetype = await _unitofWork.LeaveTypeRepository.GetAsync(request.LeaveTypeDTO.Id);
        _mapper.Map(request.LeaveTypeDTO, leavetype);
        await _unitofWork.LeaveTypeRepository.UpdateAsync(leavetype);
        await _unitofWork.Save();
        return Unit.Value;
    }
}
