using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CotacaoApp.Util
{

    public class UtilEmailMessage
    {
        public void EnviarEmail(string emailTitulo, string emailDestino, string corpoDoEmail)
        {
            //Specify senders gmail address
            string SendersAddress = "buscaseguros@outlook.com";
            //Specify The password of gmial account u are using to sent mail(pw of sender@gmail.com)
            const string SendersPassword = "123@Seguros";
            //Specify The Address You want to sent Email To(can be any valid email address)
            string ReceiversAddress = emailDestino;
            //Write the subject of ur mail
            string subject = "Proposta - BuscaSeguros";
            //Write the contents of your mail
            //const string body = "Email de teste do Projeto - enviado com Gmail";

            // var templateService = new TemplateService();
            subject = emailTitulo != null ? emailTitulo : subject;

            MailMessage sendmsg = new MailMessage(SendersAddress, ReceiversAddress, subject, corpoDoEmail);
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.live.com";
            client.Port = Convert.ToInt16("587");
            client.EnableSsl = true;
            sendmsg.IsBodyHtml = true;

            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(SendersAddress, SendersPassword);
            

            client.Send(sendmsg);
        }

        //static void Main(string[] args)
        //{

        //    //Specify senders gmail address
        //    string SendersAddress = "rfrancochagas@gmail.com";
        //    //Specify The Address You want to sent Email To(can be any valid email address)
        //    string ReceiversAddress = "rennanchagas@hotmail.com";
        //    //Specify The password of gmial account u are using to sent mail(pw of sender@gmail.com)
        //    const string SendersPassword = "helama42";
        //    //Write the subject of ur mail
        //    const string subject = "Testando";
        //    //Write the contents of your mail
        //    const string body = "Email de teste do Projeto - enviado com Gmail";

        //    try
        //    {
        //        //we will use Smtp client which allows us to send email using SMTP Protocol
        //        //i have specified the properties of SmtpClient smtp within{}
        //        //gmails smtp server name is smtp.gmail.com and port number is 587
        //        SmtpClient smtp = new SmtpClient
        //        {
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            Credentials = new NetworkCredential(SendersAddress, SendersPassword),
        //            Timeout = 3000
        //        };

        //        //MailMessage represents a mail message
        //        //it is 4 parameters(From,TO,subject,body)

        //        MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject, body);
        //        /*WE use smtp sever we specified above to send the message(MailMessage message)*/

        //        smtp.Send(message);
        //        Console.WriteLine("Funcionou!!!!");
        //        Console.ReadKey();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadKey();
        //    }
        //}
    }
}