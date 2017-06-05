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
		LibNetEntities dbContext;

		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void ValidateUser(object sender, AuthenticateEventArgs e)
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
			using (LibNetEntities db = new LibNetEntities())
			{
				Console.WriteLine(db.Database.Connection.ConnectionString);
			}
			using (LibNetEntities db = new LibNetEntities())
			{
				Console.WriteLine(db.AdminInfo.Any(x => x.AdminLogin == userName && x.AdminPassword == password));
				return db.AdminInfo.Any(x => x.AdminLogin == userName && x.AdminPassword == password);
			}
		}
	}
}