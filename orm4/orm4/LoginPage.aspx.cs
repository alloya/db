using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace orm4
{
	public partial class LoginPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void ValidateUser(object sender, AuthenticateEventArgs e)
		{
			e.Authenticated = IsMatches(Login1.UserName, Login1.Password);
		}

		private bool IsMatches(string userName, string password)
		{
			using (LibNetEntities db = new LibNetEntities())
			{
				return db.AdminInfo.Any(x => x.AdminLogin == userName && x.AdminPassword == password);
			}
		}
	}
}