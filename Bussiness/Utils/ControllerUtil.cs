using System.Collections.Generic;
using Business.Utils.Bases;

namespace Business.Utils
{
    public class ControllerUtil : IControllerUtil
    {
        public Dictionary<string, string> LiActives { get; set; }

        public ControllerUtil()
        {
            LiActives = new Dictionary<string, string>
            {
                { "Home", "" },
                { "Olay", "" },
                { "Login", "" },
                { "Register", "" },
                { "Context", "" },
                { "IslemDurumu", "" },
                { "Ihbar", "" },
                { "Cookies", "" }
            };
        }

        public void SetLiActive(string key)
        {
            LiActives[key] = "li-active";
        }
    }
}
