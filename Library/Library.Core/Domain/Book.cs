using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
        ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
