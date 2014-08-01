using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using System.Net;
using System.Net.Mail;

public class MailMaster
{
    private string mailTo;
    private string mailFrom;
    private string mailSubject;
    private string mailBody;
    private bool blnFlag;
    private int portNumber;

    private MailMessage mailMessage;
    private SmtpClient smtpClient;
    private NetworkCredential authenticationInfo;

    public string MailTo
    {
        get { return this.mailTo; }
        set { this.mailTo = value; }
    }

    public string MailFrom
    {
        get { return this.mailFrom; }
        set { this.mailFrom = value; }
    }

    public string MailSubject
    {
        get { return this.mailSubject; }
        set { this.mailSubject = value; }
    }

    public string MailBody
    {
        get { return this.mailBody; }
        set { this.mailBody = value; }
    }

    public bool IsHTMLBody
    {
        get { return this.blnFlag; }
        set { this.blnFlag = value; }
    }

    public int PortNumber
    {
        get { return this.portNumber; }
        set { this.portNumber = value; }
    }

    public MailMaster()
    {
        this.mailTo = string.Empty;
        this.mailFrom = string.Empty;
        this.mailSubject = string.Empty;
        this.mailBody = string.Empty;
        this.blnFlag = false;
        this.portNumber = 25;

        this.mailMessage = new MailMessage();
        this.smtpClient = new SmtpClient();
    }

    public void SendMail()
    {
            this.mailMessage.To.Add(MailTo);
            this.mailMessage.From = new MailAddress(MailFrom);
            this.mailMessage.Subject = MailSubject;
            this.mailMessage.Body = MailBody;
            this.mailMessage.IsBodyHtml = IsHTMLBody;

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("apps@apnerdeal.com", "Adeal12345678!"); // enter your user name and password for gmail 
            client.Port = 25; //use 465 or 587 ports for gmail     //use 25          
            client.Host = "mail.apnerdeal.com";// for gmail            //use "127.0.0.1";
            client.EnableSsl = false; // true for gmail 


            //this.smtpClient.Host = "mail.apnerdeal.com";
            //smtpClient.Host = "mail-fwd";
         
        //MailMessage message = mailMessage;
            
        try
            {
            client.Send(mailMessage);

            //this.smtpClient.Send(mailMessage);
        }
        catch
        {
            throw;
        }
    }

    public static void SendMail(string MailTo, string MailFrom, string MailSubject, string MailBody)
    {

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(MailFrom);
        mailMessage.To.Add(MailTo);
        mailMessage.Subject = MailSubject;
        mailMessage.IsBodyHtml = true;
 //       mailMessage.BodyEncoding = Encoding.UTF8;
        mailMessage.Body = MailBody;
        mailMessage.Priority = MailPriority.Normal;

        // Smtp configuration for localhost / gmail 
        SmtpClient client = new SmtpClient();
        client.Credentials = new NetworkCredential("apps@apnerdeal.com", "Adeal12345678!"); // enter your user name and password for gmail 
        client.Port = 25; //use 465 or 587 ports for gmail     //use 25          
        client.Host = "mail.apnerdeal.com";// for gmail            //use "127.0.0.1";
        client.EnableSsl = false; // true for gmail 

        MailMessage message = mailMessage;

        try
        {
            client.Send(message);
          //  Show("sending mail........");

        }
        catch 
        {
            throw;
            // Show("Sending fail.." + ex.ToString());
        }

    //    try
    //    {
    //        MailMessage mailMessage = new MailMessage();
    //        SmtpClient smtpClient = new SmtpClient();

    //        mailMessage.To.Add(MailTo);
    //        mailMessage.From = new MailAddress(MailFrom);
    //        mailMessage.Subject = MailSubject;
    //        mailMessage.Body = MailBody;
    //        mailMessage.IsBodyHtml = true;

    //        smtpClient.Host = "mail.apnerdeal.com";
    //        smtpClient.Host = "mail-fwd";

            


    //        smtpClient.Send(mailMessage);
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    }
}
