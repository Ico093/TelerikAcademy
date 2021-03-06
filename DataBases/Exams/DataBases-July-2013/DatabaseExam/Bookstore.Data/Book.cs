//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bookstore.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Reviews = new HashSet<Review>();
        }
    
        public int BooksId { get; set; }
        public string Title { get; set; }
        public string ISBNnumber { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Website { get; set; }
    
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
