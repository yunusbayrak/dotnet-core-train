using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class IslemDurumuDal : IslemDurumuDalBase
    {
        public IslemDurumuDal(DbContext context) : base(context)
        {

        }
    }
}
