using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class KullaniciDalBase : RepositoryBase<Kullanici>
    {
        protected KullaniciDalBase(DbContext context) : base(context)
        {
            
        }
    }
}
