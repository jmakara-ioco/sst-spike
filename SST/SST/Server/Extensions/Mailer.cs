using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SST.Server
{
    public class Mailer
    {
        public async Task<bool> SendEmailSmtp(string HostAddress, string HeaderImage, string Body, string FooterImage, string ToAddress, string FromAddress, string Cc, string Subject, string Greeting, int PortNumber, string Username, string Password)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(HostAddress);
            mail.From = new MailAddress(FromAddress);
            mail.To.Add(ToAddress);
            if (Cc != "")
            {
                mail.CC.Add(Cc);
            }
            mail.Subject = Subject;
            string htmlBody = @"<table CELLSPACING='0' CELLPADDING='0'>
                                    @Header
                                    <tr>
                                        <td>
                                            <p style='line-height:25px'>
                                                " + Greeting + @",<br/><br/>
                                                " + Body + @"<br/><br/>
                                                Kind Regards <br/><br/>
                                                SST Administration<br/>
                                            </p>
                                        </td>
                                    </tr>
                                    @Footer
                                </table>";
            if (HeaderImage != "")
            {
                htmlBody = htmlBody.Replace("@Header", @"<tr>
                            <td>
                                <center>
                                    <img style='padding-top: 20px;' src ='data:image/png;base64," + HeaderImage + @"' />
                                </center>
                            </td>
                        </tr>");
            }
            else
            {
                htmlBody = htmlBody.Replace("@Header", "");
            }

            if (FooterImage != "")
            {
                htmlBody = htmlBody.Replace("@Footer", @"<tr>
                            <td>
                                <center>
                                    <img style='padding-top: 20px;' src ='data:image/png;base64," + FooterImage + @"' />
                                </center>
                            </td>
                        </tr>");
            }
            else
            {
                htmlBody = htmlBody.Replace("@Footer", "");
            }


            mail.Body = htmlBody;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;

            SmtpServer.Port = PortNumber;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Username, Password);
            SmtpServer.EnableSsl = true;

            await SmtpServer.SendMailAsync(mail);
            return true;
        }
    }
}
