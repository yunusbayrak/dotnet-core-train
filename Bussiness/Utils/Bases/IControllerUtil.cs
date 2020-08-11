using System.Collections.Generic;

namespace Business.Utils.Bases
{
    public interface IControllerUtil
    {
        Dictionary<string, string> LiActives { get; set; }
        void SetLiActive(string key);
    }
}
