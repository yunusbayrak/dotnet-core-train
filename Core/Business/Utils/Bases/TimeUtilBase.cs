using System.Collections.Generic;

namespace Core.Business.Utils.Bases
{
    public abstract class TimeUtilBase
    {
        public List<string> Hours { get; }
        public List<string> Minutes { get; }

        protected TimeUtilBase()
        {
            Hours = new List<string>();
            Minutes = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                Hours.Add(i.ToString().PadLeft(2, '0'));
            }
            for (int i = 0; i < 60; i++)
            {
                Minutes.Add(i.ToString().PadLeft(2, '0'));
            }
        }
    }
}
