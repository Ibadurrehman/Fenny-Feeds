using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FennyFeeds.HelperClasses
{
    public class Utility_FF
    {

        public delegate string EmailTemplate(IEnumerable<string> parameters);

        public const string ServerURL = "http://www.fennyfeeds.com/"; //"http://keywealth.kreyonsystems.com";
        public const string Currency = "<i class='mdi mdi-currency-inr'></i>";//&nbsp;

        public static string Root_Path()
        {
            string Root_Path = "";
            if (HttpContext.Current.Request.Url.Host == "localhost")
            {
                return Root_Path = "/content";
            }
            else
            {
               return Root_Path = HttpContext.Current.Server.MapPath("~/content");
            }
        }
        
        public static Dictionary<string, string> Credentials
        {
            get
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("reply@fennyfeeds.com", "gDsu83#6");
                d.Add("noreply@fennyfeeds.com", "MAYANK27@mayank");
                //d.Add("info@rentzzz.com", "kreyonsys");
                //d.Add("mail@rentzzz.com", "kreyonsys");

                return d;
            }
        }

        public static int skipCountForMail = 0;

        public static bool SendMail(IEnumerable<string> list, EmailTemplate template, string[] Parameters, string Subject = "", IEnumerable<string> AttachmentFiles = null)
        {
            Subject = Subject ?? "";
            if (Parameters == null)
            {
                return false;
            }
        // Below line for goto
        RepeatedItrationForSendingMails:
            try
            {
                Subject = Subject.Equals("") ? "A new notification from Fenny Feeds " : Subject;
                string content = template(Parameters.OfType<string>());
                if (content == null)
                {
                    return false;
                }

                // const string SERVER = "igw5002.site4now.net";
                System.Net.Mail.MailMessage oMail = new System.Net.Mail.MailMessage();
                oMail.From = new System.Net.Mail.MailAddress("reply@fennyfeeds.com", "Fenny Feeds");

                foreach (var item in list)
                {
                    oMail.Bcc.Add(new System.Net.Mail.MailAddress(item));
                }
                oMail.Subject = Subject;
                oMail.IsBodyHtml = true; // enumeration
                oMail.Priority = System.Net.Mail.MailPriority.High; // enumeration
                oMail.Body = content;

                if (AttachmentFiles != null)
                {
                    System.Net.Mail.Attachment attachment;
                    foreach (string myfiles in AttachmentFiles)
                    {
                        attachment = new System.Net.Mail.Attachment(myfiles);
                        oMail.Attachments.Add(attachment);
                    }
                }

                //const string SERVER = "smtpout.secureserver.net";
                const string SERVER = "mail.fennyfeeds.com";//"smtpout.asia.secureserver.net";

                System.Net.Mail.SmtpClient sC = new System.Net.Mail.SmtpClient();
                sC.Host = SERVER;
                sC.Port = 25;// 587;// 80;

                var credentialData = Credentials.Skip(skipCountForMail).FirstOrDefault();

                if (credentialData.Key == null)
                {
                    return false;
                }

                string mailUsernameID = credentialData.Key;
                string mailUsernamePwd = credentialData.Value;

                System.Net.NetworkCredential nc = new System.Net.NetworkCredential(mailUsernameID, mailUsernamePwd);
                sC.Credentials = nc;
                sC.EnableSsl = false;
                try
                {
                    sC.Send(oMail);
                }
                catch (Exception ex)
                {
                    string Path = System.Web.HttpContext.Current.Server.MapPath("~/tempSaveFile.txt");

                    System.IO.StreamWriter dynamicSw = new System.IO.StreamWriter(Path, true);
                    dynamicSw.WriteLine("From Normal Mail : Date(" + DateTime.UtcNow.AddMinutes(330).ToString("dd-MMM-yyyy") + ") :" + ex.Message);
                    dynamicSw.Close(); dynamicSw.Dispose();
                }


                oMail = null;

                return true;
            }

            catch (Exception ex)
            {
                string Path = System.Web.HttpContext.Current.Server.MapPath("~/tempSaveFile.txt");

                System.IO.StreamWriter dynamicSw = new System.IO.StreamWriter(Path, true);
                dynamicSw.WriteLine("From Normal Mail : Date(" + DateTime.UtcNow.AddMinutes(330).ToString("dd-MMM-yyyy") + ") :" + ex.Message);
                dynamicSw.Close(); dynamicSw.Dispose();

                if (ex.Message.ToLower().Contains("send quota"))
                {
                    //Due to a day mail quota exceed their limit
                    skipCountForMail++;
                    goto RepeatedItrationForSendingMails;

                }
                else if (ex.Message.ToLower().Equals("failure sending mail."))
                {
                    //Due to network error

                }
                else
                {

                    //Due to no response from the server

                }

                return false;
            }

        }

    }
}