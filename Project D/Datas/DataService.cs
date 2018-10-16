using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.Datas
{
    internal class DataService
    {

        public IEnumerable<Rule> GetRules()
        {
            return new List<Rule>
            {
                new Rule{ Name= "rule 1",Destination="C:",Extensions= new List<string>{"zip","jpg" } ,Format="<[><]>" },
                //new Rule{ Name= "rule 2",Destination="D:",Extensions= new List<string>{"zip","jpg" },Format="<[><]>" },
                //new Rule{ Name= "rule 3",Destination="E:",Extensions= new List<string>{"zip","jpg" } ,Format="<[><]>" },
            }; ;
        }

        public void UpdateRule(Rule rule)
        {
        }
    }
}
