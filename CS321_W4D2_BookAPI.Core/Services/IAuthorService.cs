using System.Collections.Generic;
using CS321_W4D2_BookAPI.Core.Models;

namespace CS321_W4D2_BookAPI.Core.Services
{
    public interface IAuthorService
    {
        // CRUDL - create (add), read (get), update, delete (remove), list

        // create
        Author Add(Author todo);
        // read
        Author Get(int id);
        // update
        Author Update(Author todo); 
        // delete
        void Remove(Author todo);
        // list
        IEnumerable<Author> GetAll();
    }
}
