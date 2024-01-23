using MassageGirls.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace MassageGirls.Controllers
{
    public class MailController : Controller
    {
        [HttpPost]
        public IActionResult ProcessForm(BuyNowModel bn, ContactUsModel cu, LogicModel l)
        {
            if (ModelState.IsValid)
            {
                string body;
                if (!string.IsNullOrEmpty(bn.Name)) // Check if formData contains fields specific to the first method
                {
                    body = ConstructBodyFromBuyNowModel(bn);
                    l.Subject = "Buy Now";
                }
                else if (!string.IsNullOrEmpty(cu.NameC)) // Check if mailModel contains fields specific to the second method
                {
                    body = ConstructBodyFromContactUsModel(cu);
                    l.Subject = "Contact Us";
                }
                else
                {
                    // Handle the case where neither set of data is present
                    return BadRequest("Invalid form data");
                }


                using (var client = new SmtpClient())
                {
                    client.Host = l.Smtp; // Your SMTP server (e.g., Gmail)
                    client.Port = l.Port; // SMTP Port (Gmail uses 587)
                    //client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(l.Login, l.Password);
                    var message = new MailMessage();
                    message.From = new MailAddress(l.FromEmail, l.FromName); // Your email address
                    string[] toEmails = l.ToEmail.Split(',');
                    foreach (string email in toEmails)
                    {
                        message.To.Add(email.Trim());
                    }
                    message.Subject = l.Subject; // Email subject
                    message.IsBodyHtml = true;
                    message.Body = body;



                    client.Send(message);
                }
                return RedirectToAction("ThankYou", "Home");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return RedirectToAction("Index", "Home");
        }

        private string ConstructBodyFromBuyNowModel(BuyNowModel bn)
        {
            return $"Name: {bn.Name}<br>" +
                              $"Phone: {bn.Phone}<br>" +
                              $"Email: {bn.Email}<br>" +
                              $"City: {bn.City}<br>" +
                              $"First Girl: {bn.FirstGirl}<br>" +
                              $"Second Girl: {bn.SecondGirl}<br>" +
                              $"City: {bn.City}<br>" +
                              $"Message: {bn.Message}<br>";
        }
        private string ConstructBodyFromContactUsModel(ContactUsModel cu)
        {
            return $"Name: {cu.NameC}<br>" +
            $"Phone: {cu.PhoneC}<br>" +
            $"Email: {cu.EmailC}<br>" +
                              $"City: {cu.CityC}<br>" +
                              $"Message: {cu.MessageC}<br>";
        }
    }
}
