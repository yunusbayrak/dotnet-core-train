using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class KullaniciDal : KullaniciDalBase
    {
        public KullaniciDal(DbContext context) : base(context)
        {
            
        }
    }
}
