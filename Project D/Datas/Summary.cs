using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.Datas
{
    public class Summary
    {
        public List<Result> Success => new List<Result>();
        public List<Result> Failure => new List<Result>();
        public List<Result> NewFolders => new List<Result>();
        public List<Result> NotFoundFolders => new List<Result>();
    }
}
