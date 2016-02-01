using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Sedion.SimpleTask.Emailing
{
    public class MailHelper
    {
        private static EmailProvider _emaillProvider;

        private static void SetMailProvider(string mailAddress)
        {
            mailAddress = mailAddress.ToLower();
            if (mailAddress.Contains("@163.com"))
            {
                _emaillProvider = EmailProvider.网易163;
            }
            else if (mailAddress.Contains("@gmail.com"))
            {
                _emaillProvider = EmailProvider.谷歌;
            }
            else if (mailAddress.Contains("@skywalk.cn"))
            {
                _emaillProvider = EmailProvider.天行;
            }
            else if (mailAddress.Contains("@qq.com"))
            {
                _emaillProvider = EmailProvider.腾讯;
            }
            else if (mailAddress.Contains("@126.com"))
            {
                _emaillProvider = EmailProvider.网易126;
            }
            else if (mailAddress.Contains("@sina.cn"))
            {
                _emaillProvider = EmailProvider.新浪;
            }
            else
            {
                _emaillProvider = EmailProvider.未知;
            }
        }

        private static MailHost GetSmtpMailHost()
        {
            var mailHost = new MailHost();

            switch (_emaillProvider)
            {
                case EmailProvider.网易163:
                    mailHost.Host = "smtp.163.com";
                    mailHost.Port = 25;
                    mailHost.EnableSsl = false;
                    break;
                case EmailProvider.网易126:
                    mailHost.Host = "smtp.126.com";
                    mailHost.Port = 25;
                    mailHost.EnableSsl = false;
                    break;
                case EmailProvider.谷歌:
                    mailHost.Host = "smtp.gmail.com";
                    mailHost.Port = 587;
                    mailHost.EnableSsl = true;
                    break;
                case EmailProvider.新浪:
                    mailHost.Host = "smtp.sina.cn";
                    mailHost.Port = 25;
                    mailHost.EnableSsl = false;
                    break;
                case EmailProvider.天行:
                    mailHost.Host = "mail.skywalk.cn";
                    mailHost.Port = 25;
                    mailHost.EnableSsl = false;
                    break;
                case EmailProvider.腾讯:
                    mailHost.Host = "smtp.qq.com";
                    mailHost.Port = 25;
                    mailHost.EnableSsl = false;
                    break;
            }

            return mailHost;
        }

        private static MailHost GetPopMailHost()
        {
            //var mail = Regex.Match(mailAddress, @"@\w+([-.]\w+)*\.").Value;

            var mailHost = new MailHost();
            switch (_emaillProvider)
            {
                case EmailProvider.网易163:
                    mailHost.Host = "pop.163.com";
                    mailHost.Port = 110;
                    break;
                case EmailProvider.网易126:
                    mailHost.Host = "pop.126.com";
                    mailHost.Port = 110;
                    break;
                case EmailProvider.谷歌:
                    mailHost.Host = "pop.gmail.com";
                    mailHost.Port = 993;
                    break;
                case EmailProvider.新浪:
                    mailHost.Host = "pop.sina.cn";
                    mailHost.Port = 110;
                    break;
                case EmailProvider.天行:
                    mailHost.Host = "mail.skywalk.cn";
                    mailHost.Port = 110;
                    break;
                case EmailProvider.腾讯:
                    mailHost.Host = "pop.qq.com";
                    mailHost.Port = 110;
                    break;
            }
            return mailHost;
        }

        private static MailHost GetImapMailHost()
        {
            //var mail = Regex.Match(mailAddress, @"@\w+([-.]\w+)*\.").Value;

            var mailHost = new MailHost();
            switch (_emaillProvider)
            {
                case EmailProvider.网易163:
                    mailHost.Host = "imap.163.com";
                    mailHost.Port = 143;
                    mailHost.EnableSsl = false;
                    break;
                case EmailProvider.网易126:
                    mailHost.Host = "imap.126.com";
                    mailHost.Port = 143;
                    mailHost.EnableSsl = false;
                    break;
                case EmailProvider.谷歌:
                    mailHost.Host = "imap.gmail.com";
                    mailHost.Port = 993;
                    mailHost.EnableSsl = true;
                    break;
                case EmailProvider.新浪:
                    mailHost.Host = "imap.sina.cn";
                    mailHost.Port = 143;
                    mailHost.EnableSsl = false;
                    break;
                case EmailProvider.腾讯:
                    mailHost.Host = "imap.qq.com";
                    mailHost.Port = 143;
                    mailHost.EnableSsl = false;
                    break;
            }
            return mailHost;
        }

        public static void SendMail(MailModel mailModel)
        {
            #region 验证邮箱

            SetMailProvider(mailModel.MailFrom.Address);
            if (_emaillProvider == EmailProvider.未知)
                throw new NotImplementedException("当前系统不支持您配置的邮箱,请到个人主页修改");

            #endregion

            #region 设置收件人信息

            var mail = new MailMessage();
            mail.From = mailModel.MailFrom;
            var mailNames = mailModel.MailTo.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in mailNames)
            {
                mail.To.Add(new MailAddress(name));
            }
            mail.Body = mailModel.Body;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = mailModel.Prority;
            mail.Subject = mailModel.Subject;
            foreach (var item in mailModel.Attachments)
                mail.Attachments.Add(item);

            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

            #endregion

            #region 设置发件人信息

            var client = new SmtpClient();
            var mailHost = GetSmtpMailHost();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(mailModel.MailFrom.Address, mailModel.Password);
            client.Port = mailHost.Port;
            client.Host = mailHost.Host;
            client.EnableSsl = mailHost.EnableSsl;

            #endregion

            #region 发送邮件

            try
            {
                client.Send(mail);
            }
            catch (SmtpException sex)
            {
                throw new Exception(sex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            #endregion
        }

        private struct MailHost
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public bool EnableSsl { get; set; }
        }
    }

    public enum EmailProvider
    {
        网易163 = 0,
        网易126,
        谷歌,
        新浪,
        天行,
        腾讯,
        未知
    }
}