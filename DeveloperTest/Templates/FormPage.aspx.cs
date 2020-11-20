using System;
using System.Diagnostics;
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

        protected void inputAlert(String message)
        {
            Debug.WriteLine(message);
            string script = "<script type=\"text/javascript\">alert('" + message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }

        private bool CheckPhoneNumber(String n1, String n2)
        {
            var phoneNumber1 = n1;
            var phoneNumber2 = n2;

            bool firstIsNumeric = int.TryParse(phoneNumber1.Replace("0", "").Replace("+", ""), out int firstN);
            bool secondIsNumeric = int.TryParse(phoneNumber2.Replace("-", "").Replace("+", ""), out int secondN);

            if (phoneNumber1.Length < 1)
            {
                inputAlert("Telefon 1 måste fyllas i!");
                return false;
            }
            else if((firstIsNumeric && phoneNumber2.Length < 1) || (firstIsNumeric && secondIsNumeric))
            {
                return true;
            }
            else 
            { 
                inputAlert("Telefonnummer får bara innehålla siffrorna 0-9, - och +.");
                return false;
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

            if (CheckPhoneNumber(exPhoneOne.Text, exPhoneTwo.Text))
            {
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
}
