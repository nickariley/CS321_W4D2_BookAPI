using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using CS321_W4D2_BookAPI.Core.Models;
using CS321_W4D2_BookAPI.Core.Services;

namespace CS321_W4D2_BookAPI.Infrastructure.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookContext _bookContext;

        public AuthorRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Author Add(Author item)
        {
            _bookContext.Authors.Add(item);
            _bookContext.SaveChanges();
            return item;
        }

        public Author Get(int id)
        {
            return _bookContext.Authors
                .Include(b => b.Books)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookContext.Authors
                .Include(b => b.Books)
                .ToList();
        }

        public Author Update(Author updatedAuthor)
        {
            // get the ToDo object in the current list with this id 
            var currentAuthor = _bookContext.Authors.Find(updatedAuthor.Id);

            // return null if todo to update isn't found
            if (currentAuthor == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _bookContext.Entry(currentAuthor)
                .CurrentValues
                .SetValues(updatedAuthor);

            // update the todo and save
            _bookContext.Authors.Update(currentAuthor);
            _bookContext.SaveChanges();
            return currentAuthor;
        }

        public void Remove(Author book)
        {
            _bookContext.Authors.Remove(book);
            _bookContext.SaveChanges();
        }
    }
}
