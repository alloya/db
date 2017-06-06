using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace orm4
{
	public partial class Custom : System.Web.UI.Page
	{
		private LibNetEntities dbContext;

		protected void Page_Load(object sender, EventArgs e)
		{
			dbContext = new LibNetEntities();
		}

		protected void Button2_Click(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			var result = FirstQuery();
			Label1.Text = result.ToString();
		}

		protected void Button3_Click(object sender, EventArgs e)
		{

		}

		private IList<string> FirstQuery()
		{
			DateTime date = DateTime.ParseExact("2009-05-08", "yyyy-MM-dd",
									   System.Globalization.CultureInfo.InvariantCulture);

			var result = (from ui in dbContext.UserInfo
						  join br in dbContext.BookRent on ui.UserID equals br.UserID
						  join ba in dbContext.BookAuthor on br.BookID equals ba.BookID
						  join a in dbContext.Author on ba.AuthorID equals a.AuthorID
						  where a.BirthDate <= date
						  select ui.UserName).ToList();
			return result;
		}


	}
}