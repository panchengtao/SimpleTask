using System.Collections.Generic;
using System.Net.Mail;

namespace Sedion.SimpleTask.Emailing
{
    public class MailModel
    {
        public MailModel()
        {
            Attachments = new List<Attachment>();
        }

        /// <summary>
        ///     发件人
        /// </summary>
        public MailAddress MailFrom { get; set; }

        /// <summary>
        ///     对象
        /// </summary>
        public string MailTo { get; set; }

        /// <summary>
        ///     主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///     主体
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     优先权
        /// </summary>
        public MailPriority Prority { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     发送时间
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        ///     邮件编号
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        ///     附件
        /// </summary>
        public List<Attachment> Attachments { get; set; }
    }

    /*              使用示例
                    MailModel mailModel = new Models.MailModel()
                    {
                        MailFrom = new MailAddress(sysMail.SC_FieldName, "管理员"),
                        Password = sysMail.SC_FieldAttr,
                        MailTo = Receivers[i],
                        Subject = M_Title,
                        Body = M_Detail,
                        Prority = MailPriority.High,
                    };
                    try
                    {
                        MailHelper.SendMail(mailModel);
                    }
                    catch
                    {
                        ViewData["result"] = Receivers[i] + " 发送失败";
                        return PartialView("_ResultPartial");
                    }
    */
}