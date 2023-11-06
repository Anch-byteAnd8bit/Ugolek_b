using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.IO;

namespace ugolekback.EmailF
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string message);
    }

    public class EmailSender : IEmailSender
    {

        async Task IEmailSender.SendEmailAsync(string email, string message)
        {
            
            string? passw;
            using (StreamReader sr = new StreamReader("..\\ugolekback\\Pass.txt"))
            {
                
                passw = sr.ReadLine();
            }

            if (string.IsNullOrEmpty(passw))
            {
                // 
                throw new Exception("Не найден файл с ключом доступа к почте отправителя!");
            }

            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Подтверждение заказа", "anch-0@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Подтвердите код";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                await client.AuthenticateAsync("anch-0@yandex.ru", passw);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
