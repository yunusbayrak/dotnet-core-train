using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class IhbarDal : IhbarDalBase
    {
        public IhbarDal(DbContext context) : base(context)
        {

        }
    }
}
