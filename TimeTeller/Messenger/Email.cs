using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Messenger
{
    class Email
    {
        private String configFileName;

        public Email(String configFileName)
        {
            this.configFileName = configFileName;
        }

        public void Send(String formattedTime)
        {
            try
            {
                NetworkCredential networkCredential = new NetworkCredential(
                    GetConfigProperty("smtpUserId"),
                    GetConfigProperty("smtpUserPassword")
                );

                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress(GetConfigProperty("emailFromAddress")),
                    Subject = GetConfigProperty("emailSubject"),
                    Body = GetConfigProperty("eMailMessage") + " " + formattedTime
                };

                mailMessage.To.Add(new MailAddress(GetConfigProperty("emailToAddress")));

                SmtpClient smtpClient = new SmtpClient()
                {
                    Port = Convert.ToInt32(GetConfigProperty("smtpPort")),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = Convert.ToBoolean(GetConfigProperty("smtpUseDefaultCredentials")),
                    Host = GetConfigProperty("smtpHost"),
                    EnableSsl = Convert.ToBoolean(GetConfigProperty("smtpEnableSsl")),
                    Credentials = networkCredential
                };

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
            }
        }

        public String GetConfigProperty(String name)
        {
            String value = null;

            Regex matchPropertyName = new Regex(@"^(" + name + @"\=)(.*)$");

            String line = "";
            FileStream fileStream = new FileStream(configFileName, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                do
                {
                    line = reader.ReadLine();
                    Match match = matchPropertyName.Match(line);
                    if (match.Success)
                    {
                        value = match.Groups[2].Value;
                    }
                } while ((line != null) && (value == null));
            }
            return value;
        }
    }
}
