using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using KC_Revolution.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KC_Revolution.Controllers
{
    public class EngageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact([FromForm]ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;

                System.Net.NetworkCredential creds = new System.Net.NetworkCredential("jajoh143@gmail.com", "Johnson143!");
                client.UseDefaultCredentials = false;
                client.Credentials = creds;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("jajoh143@gmail.com");
                msg.To.Add(new MailAddress("kcrevolutionoffice@gmail.com"));

                msg.Subject = "Contact Form";
                msg.IsBodyHtml = true;
                msg.Body = string.Format(" Contact Name = {0} <br/> Email = {1} <br/>",
                    model.Name, model.Email, model.Phone);
                if (model.Phone != null)
                    msg.Body += string.Format(" Phone = {0} <br/> ", model.Phone);
                msg.Body += model.FormText;

                try
                {
                    client.Send(msg);
                    ViewBag.Message = "Your message has been successfully sent";
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error occured while sending your message. " + e.Message;
                    throw e;
                }
                var contactViewModel = new ContactFormViewModel();
                return View(contactViewModel);
            }
            else
            {
                return View(ModelState);
            }
        }

        public IActionResult Service()
        {
            return View();
        }
    }
}