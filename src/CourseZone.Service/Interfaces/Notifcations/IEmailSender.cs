using CourseZone.Service.Dtos.Notifications;

namespace CourseZone.Service.Interfaces.Notifcations;

public interface IEmailSender
{
    public Task<bool> SendAsync(EmailMessage emailMessage);
}
