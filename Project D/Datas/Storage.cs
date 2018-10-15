using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Project_D.Datas
{
    public class Storage
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public BitmapImage Thumbnail { get; set; }
        public string Extension { get; set; }
        public string FullName => Extension is null ? Name : $"{Name}.{Extension}";
        public bool IsFile => Extension is null ? false : true;
    }
}
