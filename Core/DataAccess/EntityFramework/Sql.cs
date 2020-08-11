using Core.DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class Sql : SqlBase
    {
        public Sql(DbContext context) : base(context)
        {
            
        }
    }
}
