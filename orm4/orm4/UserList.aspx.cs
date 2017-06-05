using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace orm4
{
	public partial class UserList : System.Web.UI.Page
	{
		LibNetEntities dbContext;

		protected void Page_Load(object sender, EventArgs e)
		{
			dbContext = new LibNetEntities();
			ListView1.InsertItemPosition = InsertItemPosition.LastItem;
		}

		public IQueryable<UserInfo> GetUsers()
		{
			// Используем LINQ-запрос для извлечения данных
			return dbContext.UserInfo.AsQueryable<UserInfo>();
		}

		// Редактировать данные покупателя
		public void EditUser(int? userId)
		{
			UserInfo user = dbContext.UserInfo
				.Where(c => c.UserID == userId).FirstOrDefault();

			if (user != null && TryUpdateModel<UserInfo>(user))
			{
				// Обновить данные в БД с помощью Entity Framework
				dbContext.Entry<UserInfo>(user).State = EntityState.Modified;
				dbContext.SaveChanges();
			}
		}

		// Удалить покупателя
		public void DeleteUser()
		{
			UserInfo user = new UserInfo();

			if (TryUpdateModel<UserInfo>(user))
			{
				dbContext.Entry<UserInfo>(user).State = EntityState.Deleted;
				dbContext.SaveChanges();
			}
		}

		// Вставить нового покупателя
		public void InsertUser()
		{
			UserInfo user = new UserInfo();
			user.UserRegDate = DateTime.UtcNow;

			if (TryUpdateModel<UserInfo>(user))
			{
				//user.UserRegDate = DateTime.UtcNow;
				dbContext.Entry<UserInfo>(user).State = EntityState.Added;
				dbContext.SaveChanges();
			}
		}
	}
}