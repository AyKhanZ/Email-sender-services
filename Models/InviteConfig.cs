namespace GoogleSmtpFluentEmailRazorPage.Models;

public class InviteConfig
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string PhoneNumber { get; set; }
    public string Link { get; set; }
    public DateTime DeadlineOfToken { get; set; }
}