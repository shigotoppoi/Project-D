using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.Datas
{
    public class Summery
    {
        public List<Storage> Success => new List<Storage>();
        public List<Storage> Failure => new List<Storage>();
        public List<Storage> NewFolders => new List<Storage>();
        public List<Storage> NotFoundFolders => new List<Storage>();
    }
}
