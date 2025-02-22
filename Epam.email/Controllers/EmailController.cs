using Microsoft.AspNetCore.Mvc;
using Epam.Email.Application.Services;
using System.Threading.Tasks;

namespace Epam.Email.Presentation.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailServiceApp _emailService;

        public EmailController(EmailServiceApp emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult RequestOtp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendOtp(string customerName, string customerEmail)
        {
            await _emailService.SendOtpToCustomerAsync(customerName, customerEmail);
            ViewBag.Message = "OTP has been sent successfully! Please check your email.";
            return View("RequestOtp");
        }
    }
}
