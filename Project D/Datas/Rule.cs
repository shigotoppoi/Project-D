using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.Datas
{
    public class Rule
    {
        public string Name { get; set; }
        public string Destination { get; set; }
        public bool CreateIfNew { get; set; }
        public string Extensions { get; set; }
        public string Format { get; set; }
    }
}
