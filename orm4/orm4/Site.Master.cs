﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace orm4
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.Page.User.Identity.IsAuthenticated)
			{
				FormsAuthentication.RedirectToLoginPage();
			}
		}
	}
}