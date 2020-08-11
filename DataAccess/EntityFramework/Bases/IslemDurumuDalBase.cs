using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class IslemDurumuDalBase : RepositoryBase<IslemDurumu>
    {
        protected IslemDurumuDalBase(DbContext context) : base(context)
        {

        }
    }
}
