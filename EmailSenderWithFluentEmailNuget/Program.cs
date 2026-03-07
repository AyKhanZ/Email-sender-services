using System.Net;
using System.Net.Mail;
using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
    .AddSmtpSender(smtp);

var host = builder.Build();

var email = host.Services.GetRequiredService<IFluentEmail>();

await email
    .To("zeynalovayxan70@gmail.com")
    .Subject("Test subject")
    .Body("Test body <h1>heading</h1>",true)
    .SendAsync();