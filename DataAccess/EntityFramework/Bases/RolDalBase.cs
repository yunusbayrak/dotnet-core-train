using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class RolDalBase : RepositoryBase<Rol>
    {
        protected RolDalBase(DbContext context) : base(context)
        {
            
        }
    }
}
