using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class VW_OlayDalBase : RepositoryBase<VW_Olay>
    {
        protected VW_OlayDalBase(DbContext db) : base(db)
        {

        }
    }
}
