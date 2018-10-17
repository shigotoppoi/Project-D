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
        public SortViewModel()
        {
            ChangeDirectionCommand = new RelayCommand(ChangeDirection);
        }

        public RelayCommand ChangeDirectionCommand { get; }
        public Kind Kind { get; set; }
        public string Content { get; set; }
        public Direction Direction
        {
            get => This.Direction;
            set => SetProperty(This.Direction, value, () => This.Direction = value);
        }
        public override string ToString()
        {
            return Content;
        }

        public void ChangeDirection()
        {
            Direction = Direction == Direction.Ascendant ? Direction.Descendant : Direction.Ascendant;
        }
    }
}
