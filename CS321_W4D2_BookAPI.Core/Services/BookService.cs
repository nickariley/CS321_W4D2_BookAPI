using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_BookAPI.Core.Models;

namespace CS321_W4D2_BookAPI.Core.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            // TODO: keep a reference to the BookContext in _bookContext
            _bookRepo = bookRepo;
        }

        public Book Add(Book book)
        {
            // TODO: implement add
            _bookRepo.Add(book);
            return book;
        }

        public Book Get(int id)
        {
            // TODO: return the specified Book using Find()
            return _bookRepo.Get(id);
        }

        public IEnumerable<Book> GetAll()
        {
            // TODO: return all Books using ToList()
            return _bookRepo.GetAll();
        }

        public IEnumerable<Book> GetBooksForAuthor(int authorId)
        {
            return _bookRepo.GetBooksForAuthor(authorId);
        }

        public Book Update(Book updatedBook)
        {
            // update the todo and save
            var book = _bookRepo.Update(updatedBook);
            return book;
        }

        public void Remove(Book book)
        {
            // TODO: remove the book
            _bookRepo.Remove(book);
        }

    }
}
