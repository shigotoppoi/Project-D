using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.Models
{
    public class RuleMainModel
    {
        public RuleMainModel()
        {
            _dataService = new DataService();
            _rules = _dataService.GetRules().ToList();
        }

        DataService _dataService;
        List<Rule> _rules;

        public List<Rule> GetRules()
        {
            return _rules;
        }

        public void AddRule(Rule rule)
        {
            if(!_rules.Contains(rule))
            {
                _rules.Add(rule);
            }
        }

        public void RemoveRule(Rule rule)
        {
            if (!_rules.Contains(rule))
            {
                _rules.Remove(rule);
            }
        }
    }
}
