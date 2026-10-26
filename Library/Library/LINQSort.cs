using Library.Core.Domain;
namespace Library
{
    public class LINQSort
    {
        public List<Book> BooksByYear(List<Book> books, string year)
        {
            return books.Where(x => x.PublishedYear.ToString().Contains(year))
                .ToList();
        }
        public List<Book> BooksByTitle(List<Book> books, string title)
        {
            return books.Where(x => x.Title.ToLower().Contains(title.ToLower()))
                .ToList();
        }
        public List<Book> UnavaliableBooks
            (List<Book> books)
        {
            return books
                .Where(x => !x.IsAvailable)
                .ToList();
        }

        public List<Loan> ReaderLoans
            (List<Loan> loans, Guid readerId)
        {
            return loans
                .Where(x => x.ReaderId == readerId)
                .ToList();
        } 
    }
    }
