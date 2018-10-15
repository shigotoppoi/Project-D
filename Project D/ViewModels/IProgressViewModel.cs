using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    public interface IProgressViewModel
    {
        double Value { get; }
        double Maximum { get; }
        double Minimum { get; }

        Task RunAsync();
        string ToString();
    }
}
