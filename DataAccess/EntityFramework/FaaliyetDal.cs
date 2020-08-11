using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class FaaliyetDal : FaaliyetDalBase
    {
        public FaaliyetDal(DbContext context) : base(context)
        {
            
        }
    }
}
