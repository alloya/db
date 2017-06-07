using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using orm4.Models;

namespace orm4
{
	public partial class BookList : System.Web.UI.Page
	{
		private LibNetEntities dbContext;

		protected void Page_Load(object sender, EventArgs e)
		{
			dbContext = new LibNetEntities();
		}

		public IEnumerable<BookViewModel> GetBooks()
		{
			var result = (from ab in dbContext.Book
						 join b in dbContext.BookAuthor on ab.BookID equals b.BookID
						 join a in dbContext.Author on b.AuthorID equals a.AuthorID
						 join c in dbContext.BookLocation on ab.BookID equals c.BookID
						 join l in dbContext.Library on c.LibraryID equals l.LibraryID
						 select new BookViewModel
						 {
							 BookID = ab.BookID,
							 BookName = ab.BookName,
							 AuthorName = a.AuthorName,
							 PublishYear = ab.PublishYear,
							 BookLocation = l.LibraryName
						 }).ToList();

			return result;
		}

		public void EditBook(int? bookId)
		{
			Book book = dbContext.Book
				.Where(c => c.BookID == bookId).FirstOrDefault();

			BookAuthor bookAuthor = dbContext.BookAuthor
				.Where(c => c.BookID == bookId).FirstOrDefault();
			Author author = dbContext.Author
				.Where(c => c.AuthorID == bookAuthor.AuthorID).FirstOrDefault();

			if (book != null && TryUpdateModel<Book>(book))
			{
				dbContext.Entry<Book>(book).State = EntityState.Modified;
				dbContext.SaveChanges();
			}
		}

		public void DeleteUser()
		{
			UserInfo user = new UserInfo();

			if (TryUpdateModel<UserInfo>(user))
			{
				dbContext.Entry<UserInfo>(user).State = EntityState.Deleted;
				dbContext.SaveChanges();
			}
		}

		public void InsertUser()
		{
			UserInfo user = new UserInfo();
			user.UserRegDate = DateTime.UtcNow;

			if (TryUpdateModel<UserInfo>(user))
			{
				dbContext.Entry<UserInfo>(user).State = EntityState.Added;
				dbContext.SaveChanges();
			}
		}
	}
}