using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class OlayDal : OlayDalBase
    {
        public OlayDal(DbContext context) : base(context)
        {
            
        }
    }
}
