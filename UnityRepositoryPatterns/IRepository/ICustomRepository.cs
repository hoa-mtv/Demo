using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityRepositoryPatterns.Models;

namespace UnityRepositoryPatterns.IRepository
{
    public interface ICustomRepository : IRepository<Book>
    {      
        IEnumerable<Book> GetTop5CostlyBook();

        IEnumerable<Book> GetBookAutherWise(long AutherID);
    }
}
