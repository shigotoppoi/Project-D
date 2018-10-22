using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Project_D.ViewModels
{
    internal class ResultMainViewModel
    {
        public ResultMainViewModel(object result)
        {
            _result = result as Summary;;

            List<Result> summaries = new List<Result>
            {
                new Result{Header="Source Not Found",Storages=}
            }
        }

        private Summary _result { get; }

        public IEnumerable<Result> Summaries { get; }
    }
}
