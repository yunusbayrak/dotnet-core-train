using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class FaaliyetDalBase : RepositoryBase<Faaliyet>
    {
        protected FaaliyetDalBase(DbContext context) : base(context)
        {

        }
    }
}
