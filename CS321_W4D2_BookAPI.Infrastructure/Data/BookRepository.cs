using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using CS321_W4D2_BookAPI.Core.Models;
using CS321_W4D2_BookAPI.Core.Services;

namespace CS321_W4D2_BookAPI.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookContext;

        public BookRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Book Add(Book item)
        {
            _bookContext.Books.Add(item);
            _bookContext.SaveChanges();
            return item;
        }

        public Book Get(int id)
        {
            return _bookContext.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
        }

        public IEnumerable<Book> GetBooksForAuthor(int authorId)
        {
            return _bookContext.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.AuthorId == authorId)
                .ToList();
        }

        public Book Update(Book updatedBook)
        {
            // get the ToDo object in the current list with this id 
            var currentBook = _bookContext.Books.Find(updatedBook.Id);

            // return null if todo to update isn't found
            if (currentBook == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _bookContext.Entry(currentBook)
                .CurrentValues
                .SetValues(updatedBook);

            // update the todo and save
            _bookContext.Books.Update(currentBook);
            _bookContext.SaveChanges();
            return currentBook;
        }

        public void Remove(Book book)
        {
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }
    }
}
