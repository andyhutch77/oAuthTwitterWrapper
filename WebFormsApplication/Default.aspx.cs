using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using OAuthTwitterWrapper;

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
            var oAuthTwitterWrapper = new OAuthTwitterWrapper.OAuthTwitterWrapper();
			return oAuthTwitterWrapper.GetMyTimeline();
        }
    }
}