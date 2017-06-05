using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace orm4.ASPX
{
	public partial class Login : System.Web.UI.Page
	{
		LibNetEntities dbContext;

		protected void Page_Load(object sender, EventArgs e)
		{
			//dbContext = new LibNetEntities();
			//ListView1.InsertItemPosition = InsertItemPosition.LastItem;

		}

		protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
		{

			if (!IsMatches(Login1.UserName, Login1.Password))
			{
				Login1.InstructionText = "Login or password incorrect.";
			}
			else
			{
				Login1.InstructionText = "Success.";
			}

		}

		private bool IsMatches(string userName, string password)
		{
			//var admin = dbContext.AdminInfo.ToList();
			//AdminInfo user = dbContext.AdminInfo
			//	.Where(c => c.AdminLogin == userName).FirstOrDefault();
			//var id = user.ID;
			////var credentials = ()
			using (dbContext)
			{
				var admins = dbContext.AdminInfo
					.Where(a => a.AdminLogin == userName)
					.FirstOrDefault();
				if ((admins != null) && (admins.AdminPassword == password))
				{
					return true;
				}
			}
			return false;
		}
	}
}