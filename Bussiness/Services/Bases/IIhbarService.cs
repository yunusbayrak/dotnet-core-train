using Business.Models;
using Business.Models.Filters;
using System.Collections.Generic;

namespace Business.Services.Bases
{
    public interface IIhbarService
    {
        List<IhbarModel> GetIhbarlar();
        List<IhbarModel> GetIhbarlar(IhbarFilterModel filter);
        IhbarModel GetIhbar(int id);
        bool AddIhbar(IhbarModel ihbar, bool seedContext = false);
        bool UpdateIhbar(IhbarModel ihbar);
        bool DeleteIhbar(int id);
    }
}
