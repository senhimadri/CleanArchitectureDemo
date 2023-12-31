﻿using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.DTOs.LeaveType.Validators;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Domain;
using MediatR;


namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Commands;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    //private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveTypeDTOValidator();

        var validationResult = await validator.ValidateAsync(request.leavetypeDTO);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var leavetype = _mapper.Map<LeaveType>(request.leavetypeDTO);
        leavetype = await _unitofWork.LeaveTypeRepository.AddAsync(leavetype);
        await _unitofWork.Save();

        return leavetype.Id;
    }
}
