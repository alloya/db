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
    
    public partial class BookAuthor
    {
        public long BookAuthorID { get; set; }
        public long BookID { get; set; }
        public long AuthorID { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
