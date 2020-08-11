using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class IhbarDurumuDal : IhbarDurumuDalBase
    {
        public IhbarDurumuDal(DbContext context) : base(context)
        {

        }
    }
}
