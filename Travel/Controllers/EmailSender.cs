using System.Net.Mail;
using System.Net;

namespace Travel.Controllers
{
    public class EmailSender
    {
        //if the email was send successfully(Not automatically generated code)
        internal static async Task SendEmailAsync(string email, string subject, string confirmLink)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                message.From = new MailAddress("Testing@email.com");
                message.To.Add(email);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = confirmLink;

                //find own port and hostname, create own email that you want to send it from
                smtpClient.Port = 587; //587 or 25
                smtpClient.Host = "smtp.gmail.com";

                smtpClient.EnableSsl = true;//啟用 SSL/TLS 加密連接
                smtpClient.UseDefaultCredentials = false;

                /*UserName 請輸入發送者的信箱
                 * Password則輸入對應的密碼，可使用gmail應用程式密碼(需要在設定開啟兩步驗證)
                 * 防火牆問題則更改輸入&輸出規則，TCP->port:587，且檢查是否有其他防毒軟體阻擋。*/
                smtpClient.Credentials = new NetworkCredential("UserName", "Password");

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);

            }
            catch (Exception ex)
            {
                // 在這裡拋出異常，以便在方法調用端處理
                throw new Exception("Failed to send email. See inner exception for details.", ex);
            }
        }
    }
}
