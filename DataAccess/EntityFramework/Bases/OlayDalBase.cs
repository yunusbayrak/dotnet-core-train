using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class OlayDalBase : RepositoryBase<Olay>
    {
        protected OlayDalBase(DbContext context) : base(context)
        {
            
        }
    }
}
