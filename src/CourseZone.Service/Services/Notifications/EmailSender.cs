using CourseZone.Service.Dtos.Notifications;
using CourseZone.Service.Interfaces.Notifcations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace CourseZone.Service.Services.Notifications;

public class EmailSender : IEmailSender
{
    private readonly string SENDER_EMAIL = string.Empty;
    private readonly string PLATFORM = string.Empty;
    private readonly string PASSWORD = string.Empty;
    private readonly int PORT;


    public EmailSender(IConfiguration configuration)
    {
        SENDER_EMAIL = configuration["Email:SenderEmail"]!;
        PLATFORM = configuration["Email:Platform"]!;
        PASSWORD = configuration["Email:Password"]!;
        PORT = int.Parse(configuration["Email:Port"]!);

    }
    public async Task<bool> SendAsync(EmailMessage emailMessage)
    {
        try
        {
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse(SENDER_EMAIL));
            mail.To.Add(MailboxAddress.Parse(emailMessage.Recipent));
            mail.Subject = emailMessage.Title;
            mail.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content.ToString()
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(PLATFORM, PORT, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(SENDER_EMAIL, PASSWORD);
            await smtp.SendAsync(mail);
            await smtp.DisconnectAsync(true);

            return true;
        }
        catch
        {
            return false;
        }
        
    }
}
