using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace orm4
{
	public partial class Authors : System.Web.UI.Page
	{
		private LibNetEntities dbContext;

		protected void Page_Load(object sender, EventArgs e)
		{
			dbContext = new LibNetEntities();
			ListView1.InsertItemPosition = InsertItemPosition.LastItem;
		}

		public IQueryable<Author> GetAuthors()
		{
			return dbContext.Author.AsQueryable<Author>();
		}

		public void EditAuthor(int? authorId)
		{
			Author author = dbContext.Author
				.Where(c => c.AuthorID == authorId).FirstOrDefault();

			if (author != null && TryUpdateModel<Author>(author))
			{
				dbContext.Entry<Author>(author).State = EntityState.Modified;
				dbContext.SaveChanges();
			}
		}

		public void DeleteAuthor()
		{
			Author author = new Author();

			if (TryUpdateModel<Author>(author))
			{
				dbContext.Entry<Author>(author).State = EntityState.Deleted;
				dbContext.SaveChanges();
			}
		}

		public void InsertAuthor()
		{
			Author author = new Author();

			if (TryUpdateModel<Author>(author))
			{
				dbContext.Entry<Author>(author).State = EntityState.Added;
				dbContext.SaveChanges();
			}
		}
	}
}