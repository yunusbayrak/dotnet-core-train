using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class PersonelDal : PersonelDalBase
    {
        public PersonelDal(DbContext context) : base(context)
        {

        }
    }
}
