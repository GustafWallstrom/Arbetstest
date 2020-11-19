using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DeveloperTest.DAL;
using Core.Base;

namespace DeveloperTest.Templates
{
    public partial class FormPage : Core.Controls.PageExtender
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var eid = GetEditId();
                if (eid.HasValue)
                    FillItemData(eid.Value);
            }
        }

        private void FillItemData(int id)
        {
            var item = LogItemHelper.Get(id);
            if (item == null)
                return;

            excompany.Text = item.Company;
            exContactPerson.Text = item.Contact;
            exPhoneOne.Text = item.Phone;
            exPhoneTwo.Text = item.PhoneAlt;
            exEmail.Text = item.Email;
            exQuestion.Text = item.Question;
            exAnswer.Text = item.Answer;
            exComment.Text = item.Comment;
        }

        private int? GetEditId()
        {
            return int.TryParse(Request.QueryString["edit"], out int eid) ? eid : default(int?);
        }

        protected void HandleSendClick(object sender, EventArgs e)
        {
            LogItem logItem = null;

            var eid = GetEditId();
            var user = Membership.GetUser();

            if (eid.HasValue)
            {
                logItem = LogItemHelper.Get(eid.Value);
                logItem.EditedBy = user?.Email ?? "";
            }
            else
            {
                logItem = new LogItem
                {
                    User = user?.Email ?? ""
                };
            }

            logItem.Company = excompany.Text;
            logItem.Contact = exContactPerson.Text;
            logItem.Phone = exPhoneOne.Text;
            logItem.PhoneAlt = exPhoneTwo.Text;
            logItem.Email = exEmail.Text;
            logItem.Question = exQuestion.Text;
            logItem.Answer = exAnswer.Text;
            logItem.Comment = exComment.Text;
            logItem.Date = DateTime.Now;

            logItem.Save();

            Response.Redirect(CustomPage.Get(6).PageLink);
        }
    }
}
