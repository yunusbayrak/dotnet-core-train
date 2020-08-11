using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class OlayIhbarDalBase : RepositoryBase<OlayIhbar>
    {
        protected OlayIhbarDalBase(DbContext context) : base(context)
        {
            
        }
    }
}
