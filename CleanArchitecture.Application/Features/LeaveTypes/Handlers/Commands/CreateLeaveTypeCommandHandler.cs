﻿using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.DTOs.LeaveType.Validators;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using CleanArchitecture.Domain;
using MediatR;


namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Commands;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveTypeValidator();

        var validationResult = await validator.ValidateAsync(request.leavetypeDTO);

        if (!validationResult.IsValid)
            throw new Exception();

        var leavetype = _mapper.Map<LeaveType>(request.leavetypeDTO);
        leavetype = await _leaveTypeRepository.AddAsync(leavetype);
        return leavetype.Id;
    }
}