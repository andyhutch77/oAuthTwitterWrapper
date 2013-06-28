using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using OAuthTwitterTimeLine;

namespace WebFormsApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetTwitterFeed()
        {
            var oAuthTwitterTimeline = new OAuthTwitterTimeline();
            return oAuthTwitterTimeline.GetMyTimeline();
        }
    }
}