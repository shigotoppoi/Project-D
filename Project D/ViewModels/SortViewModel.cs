using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    internal class SortViewModel : NotificationBase<Sort>
    {
        public Kind Kind { get; set; }
        public string Text { get; set; }
        public Direction Direction
        {
            get => This.Direction;
            set => SetProperty(This.Direction, value, () => This.Direction = value);
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
