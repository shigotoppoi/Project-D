using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_D.ViewModels
{
    class Utility
    {
        public static bool CheckPath(string path)
        {
            try
            {
                Path.GetFullPath(path);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
