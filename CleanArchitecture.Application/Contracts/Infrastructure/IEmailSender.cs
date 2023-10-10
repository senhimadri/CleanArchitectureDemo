using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.Contracts.Infrastructure;

public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}
