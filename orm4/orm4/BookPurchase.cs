//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace orm4
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookPurchase
    {
        public long PurchaseID { get; set; }
        public long BookID { get; set; }
        public long LibraryID { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public int BookCost { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Library Library { get; set; }
    }
}
