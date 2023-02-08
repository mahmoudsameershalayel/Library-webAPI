using Api.Dto;
using Api.Models;

namespace Api.Interfaces
{
    public interface IBookRepository
    {
        public IList<BookDto> getAllBooks();
        public BookDto findById(int id);
        public void updateBook(int id , BookDto bookDto);
        public Book deleteBook(int id);
        public void addBook(BookDto bookDto);
    }
}
