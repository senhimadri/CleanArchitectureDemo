using CleanArchitecture.Domain;
using AutoMapper;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.DTOs.LeaveType.Validators;
using CleanArchitecture.Application.DTOs.LeaveRequest.Validator;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Responses;
using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IEmailSender _emailSender;
    private readonly IMapper _mapper;


    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
                                            ILeaveTypeRepository leaveTypeRepository,
                                            IEmailSender emailSender,
                                            IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _emailSender = emailSender;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);

        var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation Failed.";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
           

        var leaverequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDTO);
        leaverequest = await _leaveRequestRepository.AddAsync(leaverequest);

        response.Success = true;
        response.Message = "Creation Successful.";
        response.Id = leaverequest.Id;

        var email = new Email
        {
            To = "employee@org.com",
            Body = $"Email Body for leave Information.",
            Subject = "Leave request submitted."
        };

        try
        {
            await _emailSender.SendEmail(email);
        }
        catch (Exception)
        {
            // Log or Handle error . but do not return.
        }

        return response;
    }
}
