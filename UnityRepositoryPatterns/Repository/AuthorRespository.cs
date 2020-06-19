using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Models;
using System.Data;
namespace UnityRepositoryPatterns.Repository
{
    public class AuthorRespository:Repository<Auther>,IAuthurResponsitory
    {
        public AuthorRespository(DBEntities context) : base(context)
        {
        }
        public DBEntities DBEntities
        {
            get { return db as DBEntities; }
        }

        public IEnumerable<Auther> getlist()
        {
            return DBEntities.Authers.ToList();
        }
        public DataTable getdb()
        {
            string sql = " select * from auther ";
            DataTable dt = Help.DataTable_Sql(sql);
            return dt;
            
        }
    }
}