using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class IhbarDalBase : RepositoryBase<Ihbar>
    {
        protected IhbarDalBase(DbContext context) : base(context)
        {

        }
    }
}
