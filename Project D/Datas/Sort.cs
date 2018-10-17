using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.Datas
{
    internal class Sort
    {
        public Sort() { }
        public Sort(string text, Kind category, Direction direction = Direction.Ascendant)
        {
            Text = text;
            Kind = category;
            Direction = direction;
        }
        public string Text { get; set; }
        public Kind Kind { get; set; }
        public Direction Direction { get; set; }
    }
}
