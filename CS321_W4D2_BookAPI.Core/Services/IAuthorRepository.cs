using System.Collections.Generic;
using CS321_W4D2_BookAPI.Core.Models;

namespace CS321_W4D2_BookAPI.Core.Services
{
    public interface IAuthorRepository
    {
        Author Add(Author item);
        Author Get(int id);
        IEnumerable<Author> GetAll();
        void Remove(Author book);
        Author Update(Author updatedAuthor);
    }
}