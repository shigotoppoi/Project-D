using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.Models
{
    public class SettingRuleModel
    {
        public SettingRuleModel()
        {
            _dataService = new DataService();
        }

        DataService _dataService;

        public IEnumerable<Rule> GetRules()
        {
            return _dataService.GetRules();
        }
    }
}
