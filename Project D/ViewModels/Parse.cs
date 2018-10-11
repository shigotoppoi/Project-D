using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    class Parse
    {
        public Parse(RuleViewModel rule)
        {
            _rule = rule;
        }

        private RuleViewModel _rule;

        public void ss()
        {
            // \(-s\)\(-s\) \[-n \(-s\)\]-s
            List<string> f = new List<string>();
            string temp = null;
            string r = _rule.Format;
            for (int i=0;i<r.Length;i++)
            {
                if (r[i].Equals('\\'))
                {
                    f.Add(r[i + 1].ToString());
                    i++;
                    continue;
                }
                else if (r[i].Equals('-'))
                {
                    f.Add(r[i + 1].ToString());
                    i++;
                    continue;
                }
                else if(r[i].Equals(' '))
                {
                    f.Add(r[i + 1].ToString());
                    i++;
                    continue;
                }
            }

            string s = @"\(-s\)\(-s\) \[-n \(-s\)\]-s";

        }
    }
}
