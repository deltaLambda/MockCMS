using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MockCMS.Models;

namespace MockCMS.Repositories
{
    public interface IRepository<T> where T : Model
    {
        void Create(T newItem);
        void Update(T updatedItem);
        void Delete(T itemToDelete);
        IList<T> Get();
        T Get(int id);
    }
}
