using Project_D.Datas;
using Project_D.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    public class RuleViewModel : NotificationBase<Rule>
    {
        public RuleViewModel(Rule rule = null) : base(rule) { }

        public bool IsEditable { get; set; } = false;

        public string Name
        {
            get => This.Name;
            set => SetProperty(This.Name, value, () => This.Name = value);
        }

        public string Destination
        {
            get => This.Destination;
            //set => _Set(This.Destination, value, nameof(Destination));
            set=>SetProperty(This.Destination, value, () => This.Destination = value);
        }

        public bool CreateIfNew
        {
            get => This.CreateIfNew;
            //set => _Set(This.CreateIfNew, value, nameof(CreateIfNew));
            set => SetProperty(This.CreateIfNew, value, () => This.CreateIfNew = value);
        }

        public string Extensions
        {
            get => This.Extensions;
            //set => _Set(This.Extensions, value, nameof(Extensions));
            set => SetProperty(This.Extensions, value, () => This.Extensions = value);
        }

        public string Format
        {
            get => This.Format;
            set => SetProperty(This.Format, value, () => This.Format = value);
        }

    }
}
