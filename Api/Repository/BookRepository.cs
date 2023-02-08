using Api.Data;
using Api.Dto;
using Api.Interfaces;
using Api.Models;
using AutoMapper;

namespace Api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BookRepository(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void addBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book deleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return book;
        }

        public BookDto findById(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            var BookDto = _mapper.Map<BookDto>(book);
            return BookDto;
        }

        public IList<BookDto> getAllBooks()
        {
            var Books = _context.Books.ToList();
            var BooksDto = _mapper.Map<List<BookDto>>(Books);
            return BooksDto;
        }

        public void updateBook(int id, BookDto bookDto)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            _context.Update(book);
            _context.SaveChanges();
        }
    }
}
