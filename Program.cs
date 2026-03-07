using System.Net;
using System.Net.Mail;
using FluentEmail.Core;
using GoogleSmtpFluentEmailRazorPage.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bogus;

var builder = Host.CreateApplicationBuilder(args);

var smtp = new SmtpClient("smtp.gmail.com", 587)
{
    EnableSsl = true,
    Credentials = new NetworkCredential(
        "info.atms.org@gmail.com",
        "gabj gjvf fbwt qcow"
    )
};

builder.Services
    .AddFluentEmail("info.atms.org@gmail.com","TestName")
    .AddRazorRenderer()
    .AddSmtpSender(smtp);

var host = builder.Build();

var email = host.Services.GetRequiredService<IFluentEmail>();
var faker = new Faker<InviteConfig>()
    .RuleFor(x => x.Email, f => f.Internet.Email())
    .RuleFor(x => x.Password, f => f.Internet.Password())
    .RuleFor(x => x.Name, f => f.Name.FirstName())
    .RuleFor(x => x.Surname, f => f.Name.LastName())
    .RuleFor(x => x.Patronymic, f => f.Name.FullName())
    .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
    .RuleFor(x => x.Link, f => f.Internet.Url())
    .RuleFor(x => x.DeadlineOfToken, f => f.Date.Future());

var fakeInvite = faker.Generate();

await email
    .To("zeynalovayxan70@gmail.com")
    .Subject("Test subject")
    .UsingTemplateFromFile("Views/EmailTemplate.cshtml", fakeInvite)
    .SendAsync();