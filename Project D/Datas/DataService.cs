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
            return  new List<Rule>
            {
                new Rule{ Name= "rule 1",Destination="C:",AcceptedExtensions= "*.zip;*.7z" ,Format="<[><]>" },
                new Rule{ Name= "rule 2",Destination="D:",AcceptedExtensions="*.zip;*.7z" ,Format="<[><]>" },
                new Rule{ Name= "rule 3",Destination="E:",AcceptedExtensions="*.zip;*.7z" ,Format="<[><]>" },
            }; ;
        }

        public void UpdateRule(Rule rule)
        {
        }
    }
}
