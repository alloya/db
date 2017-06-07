using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orm4.Models
{
	public class CustomModel
	{
		public string Username { get; set; }
		public string BookName { get; set; }
		public long ID { get; set; }
		public int PurchaseCost { get; set; }
		public Library Library { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime RentDate { get; set; }
	}


	public class BookViewModel
	{
		public long BookID { get; set; }
		public string BookName { get; set; }
		public string AuthorName { get; set; }
		public int? PublishYear { get; set; }
		public string BookLocation { get; set; }
	}
}