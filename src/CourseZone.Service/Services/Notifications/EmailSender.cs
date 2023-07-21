using CourseZone.Service.Dtos.Notifications;
using CourseZone.Service.Interfaces.Notifcations;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Net;

namespace CourseZone.Service.Services.Notifications;

public class EmailSender : IEmailSender
{
    public async Task<bool> SendAsync(EmailMessage emailMessage)
    {
        try
        {
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse("coursezoneuz@gmail.com"));
            mail.To.Add(MailboxAddress.Parse(emailMessage.Recipent));
            mail.Subject = emailMessage.Title;
            mail.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content.ToString()
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("coursezoneuz@gmail.com", "raungtjvzptpvwvh");
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
