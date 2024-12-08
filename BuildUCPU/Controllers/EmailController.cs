using Microsoft.AspNetCore.Mvc;
using BuildUCPU.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;


namespace BuildUCPU.Controllers
{
    public class EmailController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsError = true;
                ViewBag.Message = "Formularz zawiera błędy. Uzupełnij wszystkie pola.";
                return View("Index", model);
            }

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Grzegorz", _configuration["SmtpSettings:SenderEmail"]));
                message.To.Add(new MailboxAddress("", model.ToEmail));
                message.Subject = model.Subject;
                message.Body = new TextPart("plain") { Text = model.Message };

                using (var client = new SmtpClient())
                {
                    client.Connect(_configuration["SmtpSettings:Host"], int.Parse(_configuration["SmtpSettings:Port"]), false);
                    client.Authenticate(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
                    client.Send(message);
                    client.Disconnect(true);
                }

                ViewBag.IsError = false;
                ViewBag.Message = "Wiadomość została wysłana pomyślnie!";
            }
            catch (Exception ex)
            {
                ViewBag.IsError = true;
                ViewBag.Message = $"Wystąpił błąd: {ex.Message}";
            }

            return View("Index");
        }
    }
}
