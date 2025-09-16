using System;
namespace MyTestApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string ISBN { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
