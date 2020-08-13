using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class VW_OlayDal : VW_OlayDalBase
    {
        public VW_OlayDal(DbContext context) : base(context)
        {

        }
    }
}
