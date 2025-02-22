using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Epam.Email.Application.Interfaces;
using Epam.Email.Application.Services;
using Epam.Email.Domain.Repositories;
using Epam.Email.Infrastructure.Data;
using Epam.Email.Infrastructure.Repositories;
using Epam.Email.Application.Models;  



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<EmailServiceApp>();

builder.Services.Configure<SmtpCredential>(
    builder.Configuration.GetSection("SmtpSettings")
);

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Email}/{action=RequestOtp}/{id?}");  // 
});


app.Run();
