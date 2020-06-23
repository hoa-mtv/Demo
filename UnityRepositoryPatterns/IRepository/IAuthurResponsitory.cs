using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Models;
using System.Data;
namespace UnityRepositoryPatterns.IRepository
{
    //public interface IAuthurResponsitory: IRepository<Auther>
    public interface IAuthurResponsitory
    {
        IEnumerable<Auther> getlist();
        //Task<IEnumerable<Auther>> getlist();
        Auther FindAutherById(long id);
        Auther DeleteAutherById(long id);
        DataTable getdb();
    }
}
