using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Models.Email;
using Microsoft.Extensions.Options;
using Azure.Communication.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;


namespace CleanArchitecture.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    public EmailSettings EmailSettings { get; }
    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        EmailSettings = emailSettings.Value;
    }
    public async Task<bool> SendEmail(Application.Models.Email.EmailMessage email)
    {
        // Find communicaion resoure in the Azure portal
        var connectionString = "Endpoint=https://communication.azure.com/;AccessKey=your_access_key";
        var emailClient = new EmailClient(connectionString);

        // Send the message with WaitUnil.Started
        // Copilot: https://learn.microsoft.com/en-us/dotnet/api/overview/azure/communication.email-readme?view=azure-dotnet

        // Send a simple message with manual polling for status
        var emailSendOperation =  await emailClient.SendAsync(
            wait: WaitUntil.Started,
            senderAddress: EmailSettings.FromAddress,
            recipientAddress: email.To,
            subject: email.Subject,
            htmlContent: email.Body);

        // Call UpdateStatus on the email send operation to poll for the status
        try
        {
            await emailSendOperation.UpdateStatusAsync();
            if (emailSendOperation.HasCompleted)
            {
                return true;
            }
            await Task.Delay(100);
        }
        catch (RequestFailedException ex)
        {
            Console.WriteLine($"Email send operation failed with Code = {ex.ErrorCode} and Message = {ex.Message}");
        }

        if (emailSendOperation.HasValue)
        {
            // TODO: Log the status of the email send operation
            Console.WriteLine($"Email queued for delivery. Status: {emailSendOperation.Value.Status}");
        }

        string operationId = emailSendOperation.Id;
        // TODO: Log the operation ID
        Console.WriteLine($"Email send operation ID: {operationId}");

        return emailSendOperation.HasCompleted;
    }
}
