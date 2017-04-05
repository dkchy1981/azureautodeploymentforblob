using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationToSendEmailForWebJob
{
    public class Program
    {

        public static int count=0;
        public static void Main(string[] args)
        {
            SendEmail();
        }

        public static void SendEmail()
        {
            try
            {
                count++;
                

                var apiKey = "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";

                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("nayanhr@allscript.com", "Email Count '" + count.ToString() + "' Congratulation for job interview"),
                    Subject = "Email Count '" + count.ToString() + "' Congratulation for job interview. Modified for autodeployment from GitHub",
                    PlainTextContent = "Hello, Email!",
                    HtmlContent = "Hello Sir,<br/>You are selected for final round of interview. Please be present at 11:00AM with original documents. </br><br/>Thanks</br>HR- Allscript"
                };

                msg.AddCc(new EmailAddress("devendrac@sfwltd.co.uk", "Devendra Choudhary"));
                //msg.AddBcc(new EmailAddress("shyamv@sfwltd.co.uk", "Shyam Vin"));
                msg.AddCc(new EmailAddress("jenitv@sfwltd.co.uk", "Jenit Vagashiya"));
                //msg.AddTo(new EmailAddress("chiragd@sfwltd.co.uk", "Test User2"));

                /*
                Byte[] bytes = System.IO.File.ReadAllBytes(@"wwwroot\DataFiles\Emploment 2.jpg");
                String content = Convert.ToBase64String(bytes);
                msg.AddAttachment("Emploment 2.jpg", content, "image/jpg", "inline", "Banner 2");

                bytes = null;
                bytes = System.IO.File.ReadAllBytes(@"wwwroot\DataFiles\Leadership Training.docx");
                if (bytes != null)
                {
                    String content1 = Convert.ToBase64String(bytes);
                    msg.AddAttachment("Leadership Training.docx", content1, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "inline", "Leadership Training");
                }
                */

                client.SendEmailAsync(msg).Wait();


                Console.WriteLine("Email sent successfully");
                System.Threading.Thread.Sleep(30000);
                SendEmail();

            }
            catch (Exception ex)
            {
                string s = ex.Message;                
            }
        }
    }
}
