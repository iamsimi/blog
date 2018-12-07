using blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Services
{
    public interface IblogManager
    {
       void Create(Article articleToCreate, string email);
        void Edit(Article articleToEdit, int id);
       void Delete(int? id);
        Article GetOne(int? id);

    }
}
