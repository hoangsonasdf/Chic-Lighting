using System.Net.Mail;
using System.Net;
using System.Text.Encodings.Web;

namespace projectchicandlighting.Services.SendMailServices
{
    public class SendMailService : ISendMailService
    {
        private readonly IConfiguration _configuration;

        public SendMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> EmailBodyReset(string link)
        {
            return $@"<!DOCTYPE html>
                        <html>
                        <head>
                            <meta charset=""utf-8"">
                            <meta http-equiv=""x-ua-compatible"" content=""ie=edge"">
                            <title>Reset Your Password</title>
                            <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                            <style type=""text/css"">
                                body,
                                table,
                                td,
                                a {{
                                    -ms-text-size-adjust: 100%;
                                    -webkit-text-size-adjust: 100%;
                                }}
                                table,
                                td {{
                                    mso-table-rspace: 0pt;
                                    mso-table-lspace: 0pt;
                                }}
                                img {{
                                    -ms-interpolation-mode: bicubic;
                                }}
                                img {{
                                    border: 0;
                                    height: auto;
                                    line-height: 100%;
                                    outline: none;
                                    text-decoration: none;
                                }}
                                table {{
                                    border-collapse: collapse !important;
                                }}
                                body {{
                                    height: 100% !important;
                                    margin: 0 !important;
                                    padding: 0 !important;
                                    width: 100% !important;
                                }}
                                a[x-apple-data-detectors] {{
                                    color: inherit !important;
                                    text-decoration: none !important;
                                    font-size: inherit !important;
                                    font-family: inherit !important;
                                    font-weight: inherit !important;
                                    line-height: inherit !important;
                                }}
                                @media screen and (max-width: 600px) {{
                                    h1 {{
                                        font-size: 32px !important;
                                        line-height: 32px !important;
                                    }}
                                }}
                            </style>
                        </head>
                        <body style=""background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"">
                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                <tr>
                                    <td bgcolor=""#f4f4f4"" align=""center"">
                                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                                            <tr>
                                                <td bgcolor=""#ffffff"" align=""center"" style=""padding: 40px 20px 20px 20px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; line-height: 48px;"">
                                                    <h1 style=""font-size: 48px; font-weight: 400; margin: 2;"">Reset Your Password</h1>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor=""#f4f4f4"" align=""center"">
                                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                                            <tr>
                                                <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                                                    <p style=""margin: 0;"">We received a request to reset your password. Click the button below to reset it. If you did not request a password reset, you can safely ignore this email.</p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor=""#ffffff"" align=""left"">
                                                    <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                                        <tr>
                                                            <td bgcolor=""#ffffff"" align=""center"" style=""padding: 20px 30px 60px 30px;"">
                                                                <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                                                                    <tr>
                                                                        <td align=""center"" style=""border-radius: 3px;"" bgcolor=""#1a82e2""><a href='{HtmlEncoder.Default.Encode(link)}' target=""_blank"" style=""font-size: 20px; font-family: 'Lato', Helvetica, Arial, sans-serif; color: #ffffff; text-decoration: none; color: #ffffff; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid #1a82e2; display: inline-block;"">Reset Password</a></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 40px 30px; border-radius: 0px 0px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                                                    <p style=""margin: 0;"">If that doesn't work, copy and paste the following link in your browser:</p>
                                                    <p style=""margin: 0;""><a href='{HtmlEncoder.Default.Encode(link)}' target=""_blank"" style=""color: #1a82e2;"">click here</a></p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </body>
                        </html>";
        }

        public async Task<string> EmailBodyVerify(string link)
        {
            return $@"
                   <!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset=""utf-8"">
                        <meta http-equiv=""x-ua-compatible"" content=""ie=edge"">
                        <title>Verify Your Email</title>
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                        <style type=""text/css"">
                            body,
                            table,
                            td,
                            a {{
                                -ms-text-size-adjust: 100%;
                                -webkit-text-size-adjust: 100%;
                            }}
                            table,
                            td {{
                                mso-table-rspace: 0pt;
                                mso-table-lspace: 0pt;
                            }}
                            img {{
                                -ms-interpolation-mode: bicubic;
                            }}
                            img {{
                                border: 0;
                                height: auto;
                                line-height: 100%;
                                outline: none;
                                text-decoration: none;
                            }}
                            table {{
                                border-collapse: collapse !important;
                            }}
                            body {{
                                height: 100% !important;
                                margin: 0 !important;
                                padding: 0 !important;
                                width: 100% !important;
                            }}
                            a[x-apple-data-detectors] {{
                                color: inherit !important;
                                text-decoration: none !important;
                                font-size: inherit !important;
                                font-family: inherit !important;
                                font-weight: inherit !important;
                                line-height: inherit !important;
                            }}
                            @media screen and (max-width: 600px) {{
                                h1 {{
                                    font-size: 32px !important;
                                    line-height: 32px !important;
                                }}
                            }}
                        </style>
                    </head>
                    <body style=""background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"">
                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                            <tr>
                                <td bgcolor=""#f4f4f4"" align=""center"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                                        <tr>
                                            <td bgcolor=""#ffffff"" align=""center"" style=""padding: 40px 20px 20px 20px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; line-height: 48px;"">
                                                <h1 style=""font-size: 48px; font-weight: 400; margin: 2;"">Verify Your Email</h1>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor=""#f4f4f4"" align=""center"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                                        <tr>
                                            <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                                                <p style=""margin: 0;"">Thank you for signing up. Please click the button below to verify your email address. If you did not sign up, you can safely ignore this email.</p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor=""#ffffff"" align=""left"">
                                                <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                                    <tr>
                                                        <td bgcolor=""#ffffff"" align=""center"" style=""padding: 20px 30px 60px 30px;"">
                                                            <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                                                                <tr>
                                                                    <td align=""center"" style=""border-radius: 3px;"" bgcolor=""#1a82e2""><a href='{HtmlEncoder.Default.Encode(link)}' target=""_blank"" style=""font-size: 20px; font-family: 'Lato', Helvetica, Arial, sans-serif; color: #ffffff; text-decoration: none; color: #ffffff; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid #1a82e2; display: inline-block;"">Verify Email</a></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 40px 30px; border-radius: 0px 0px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                                                <p style=""margin: 0;"">If that doesn't work, copy and paste the following link in your browser:</p>
                                                <p style=""margin: 0;""><a href='{HtmlEncoder.Default.Encode(link)}' target=""_blank"" style=""color: #1a82e2;"">click here</a></p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </body>
                    </html>
                    ";
        }

        public async Task SendMail(string subject, string body, string to)
        {
            string fromMail = _configuration.GetSection("SmtpSettings:FromAddress").Value;
            string fromPassword = _configuration.GetSection("SmtpSettings:Password").Value;

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(to));
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient(_configuration.GetSection("SmtpSettings:Host").Value))
            {
                smtpClient.Port = int.Parse(_configuration.GetSection("SmtpSettings:Port").Value);
                smtpClient.Credentials = new NetworkCredential(fromMail, fromPassword);
                smtpClient.EnableSsl = bool.Parse(_configuration.GetSection("SmtpSettings:EnableSsl").Value);
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
