using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Kanban_board.Data;
using Kanban_board.Models;
using Microsoft.AspNetCore.Authorization;


namespace Kanban_board.Controllers
{
    [Authorize(Policy = "TeamPlayerAccess")]
    public class EmailController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmailController(ApplicationDbContext context)
        {
        _context = context;

        }

        public async Task<IActionResult> Index(Email email)
        {
            if (ModelState.IsValid)
            {

                var users = _context.Users.ToList();

                var mailAddress = users.Select(x => x.Email);
                var count = 0;

                foreach (var s in mailAddress)
                {
                    count++;

                    MailMessage mMessage = new MailMessage();
                    mMessage.To.Add(s);
                    mMessage.Subject = email.Subject;
                    mMessage.Body = email.Body;
                    mMessage.IsBodyHtml = false;
                    mMessage.From = new MailAddress("alexaspnet300@gmail.com");
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;

                    smtpClient.Credentials = new NetworkCredential("alexaspnet300@gmail.com", "Alextest!234");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mMessage);
                }




                //await smtpClient.SendMailAsync(mMessage);
                ViewData["Message"] = $"Email has been sent to all users, mails sendt: {count}";
            }
            return View();
        }


    }

}