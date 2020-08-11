using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class IhbarDurumuDalBase : RepositoryBase<IhbarDurumu>
    {
        protected IhbarDurumuDalBase(DbContext context) : base(context)
        {

        }
    }
}
