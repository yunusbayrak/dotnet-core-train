using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class RolDal : RolDalBase
    {
        public RolDal(DbContext context) : base(context)
        {
            
        }
    }
}
