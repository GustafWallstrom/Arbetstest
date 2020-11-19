using Core.Base;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DeveloperTest
{
    public partial class Master : Core.Controls.MasterPageExtender
    {
        public CustomPage CreatePage => CustomPage.Get(4);
        public CustomPage LogPage => CustomPage.Get(5);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                DataBind();
        }

        protected void logout_Click(object sender, EventArgs e)
        {
        }
    }
}
