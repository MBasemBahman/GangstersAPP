using MimeKit;

namespace GangstersAPP.Common
{
    public class EmailManager
    {
        private readonly string WebRootPath;

        public EmailManager(string WebRootPath)
        {
            this.WebRootPath = WebRootPath;
        }

        public async Task SendMail(string ToEmail, string Subject, string Message, bool WithTemplate = false)
        {
            await SendMail(new List<string> { ToEmail }, Subject, Message, WithTemplate);
        }

        public async Task SendMail(
            List<string> ToEmails,
            string Subject,
            string Message,
            bool WithTemplate)
        {
            try
            {
                string _email = "support@gangsters187.com";
                string _epass = "Password123!";
                string _dispName = "Gangsters App";

                if (WithTemplate)
                {
                    string pathToFile = WebRootPath
                          + Path.DirectorySeparatorChar.ToString()
                          + "Templates"
                          + Path.DirectorySeparatorChar.ToString()
                          + "EmailTemplate"
                          + Path.DirectorySeparatorChar.ToString()
                          + "VerifyEmail.html";

                    BodyBuilder builder = new();
                    using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                    {
                        builder.HtmlBody = SourceReader.ReadToEnd();
                    }

                    Message = builder.HtmlBody.Replace("{0}", Message);
                }

                MailMessage myMessage = new()
                {
                    From = new MailAddress(_email, _dispName),
                    Subject = Subject,
                    Body = Message,
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8
                };

                ToEmails.ForEach(mail => myMessage.To.Add(mail));

                using SmtpClient smtp = new()
                {
                    EnableSsl = false,
                    Host = "mail5017.site4now.net",
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_email, _epass),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                await smtp.SendMailAsync(myMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
