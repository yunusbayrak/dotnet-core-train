using System;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework.Bases
{
    public abstract class SqlBase
    {
        private readonly DbContext _context;

        protected SqlBase(DbContext context)
        {
            _context = context;
        }

        public virtual void ExecuteSql(string sql)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(sql);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
