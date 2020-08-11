using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class PersonelDalBase : RepositoryBase<Personel>
    {
        protected PersonelDalBase(DbContext context) : base(context)
        {

        }
    }
}
