using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.Datas
{
    internal class SortedKind
    {
        public SortedKind(Kind kind,string content)
        {
            Kind = kind;
            Content = content;
        }

        public Kind Kind { get;  }
        public string Content { get;  }
    }
}
