using Library.Core.Domain;
using Library.Core.Dto;


namespace Library.Core.ServiceInterface
{
    public interface IBookServices
    {
        Task<Book> Create(BookDto dto);
    }
}
