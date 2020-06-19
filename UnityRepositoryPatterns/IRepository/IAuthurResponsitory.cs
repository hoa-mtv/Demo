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
    public interface IAuthurResponsitory: IRepository<Auther>
    {
        IEnumerable<Auther> getlist();
        DataTable getdb();
    }
}
