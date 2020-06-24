using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_BookAPI.Core.Models;

namespace CS321_W4D2_BookAPI.Core.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IAuthorRepository authorRepo)
        {
            // TODO: keep a reference to the BookContext in _bookContext
            _authorRepo = authorRepo;
        }

        public Author Add(Author author)
        {
            // TODO: implement add
            _authorRepo.Add(author);
            return author;
        }

        public Author Get(int id)
        {
            // TODO: return the specified Author using Find()
            return _authorRepo.Get(id);
        }

        public IEnumerable<Author> GetAll()
        {
            // TODO: return all Authors using ToList()
            return _authorRepo.GetAll();
        }

        public Author Update(Author updatedAuthor)
        {
            // update the todo and save
            var author = _authorRepo.Update(updatedAuthor);
            return author;
        }

        public void Remove(Author author)
        {
            // TODO: remove the author
            _authorRepo.Remove(author);
        }

    }
}
