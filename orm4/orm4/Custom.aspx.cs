using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using orm4.Models;

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
			Label2.Text = string.Join(", ", SecondQuery().Select(x => $"{x.BookName} - {x.PurchaseCost}"));
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Label1.Text = string.Join(", ", FirstQuery().Select(x => $"{x.Username} - {x.RentDate.ToShortDateString()}"));
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			Label3.Text = string.Join(", ", ThirdQuery().Select(x => $"{x.BookName}"));
		}

		private IList<CustomModel> FirstQuery()
		{
			DateTime date = DateTime.ParseExact("1900-01-01", "yyyy-MM-dd",
									   System.Globalization.CultureInfo.InvariantCulture);

			var result = (from ui in dbContext.UserInfo
						  join br in dbContext.BookRent on ui.UserID equals br.UserID
						  join ba in dbContext.BookAuthor on br.BookID equals ba.BookID
						  join a in dbContext.Author on ba.AuthorID equals a.AuthorID
						  where a.BirthDate <= date
						  select new CustomModel
						  {
							  Username = ui.UserName,
							  RentDate = br.DateTaken,
						  }).ToList();
			return result;
		}

		private IList<CustomModel> SecondQuery()
		{
			DateTime date = DateTime.ParseExact("2003-03-01", "yyyy-MM-dd",
									   System.Globalization.CultureInfo.InvariantCulture);
			DateTime date1 = DateTime.ParseExact("2003-04-01", "yyyy-MM-dd",
									   System.Globalization.CultureInfo.InvariantCulture);

			var result = (from b in dbContext.Book
						  join bp in dbContext.BookPurchase on b.BookID equals bp.BookID
						  where bp.PurchaseDate >= date && bp.PurchaseDate < date1
						  select new CustomModel
						  {
							  BookName = b.BookName,
							  PurchaseCost = bp.BookCost,
						  }).ToList();
			return result;
		}

		private IList<CustomModel> ThirdQuery()
		{
			var result = (from br in dbContext.BookRent
						  join ba in dbContext.BookAuthor on br.BookID equals ba.BookID
						  join b in dbContext.Book on br.BookID equals b.BookID
						  where br.DateReturned == null
						  group b.BookName by b.BookName into grouped
						  where grouped.Count() == 2
						  select new CustomModel
						  {
							  BookName = grouped.Key
						  }).ToList();
			return result;
		}
	}
}