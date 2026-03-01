using System.Net;
using System.Net.Mail;

var service = new EmailSender();
await service.SendEmailAsync("zeynalovayxan70@gmail.com","Subject","Hello message6757ytrhgfhjgfjhgjhgjhg");

internal class EmailSender 
{
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var smtpServer = "smtp.gmail.com";
        var userName = "info.atms.org@gmail.com";
        var password = "gabj gjvf fbwt qcow";
        var smtpClient = new SmtpClient(smtpServer, 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(userName, password)
        };
        
        var message = new MailMessage(userName, to, subject, body);
        await smtpClient.SendMailAsync(message);
    }
};