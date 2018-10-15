﻿using Project_D.Datas;
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

        public string Name
        {
            get => This.Name;
            set => SetProperty(This.Name, value, () => This.Name = value);
        }

        public string Destination
        {
            get => This.Destination;
            set=>SetProperty(This.Destination, value, () => This.Destination = value);
        }

        public bool CreateIfNone
        {
            get => This.CreateIfNone;
            set => SetProperty(This.CreateIfNone, value, () => This.CreateIfNone = value);
        }

        public bool ReplaceIfExist
        {
            get => This.ReplaceIfExist;
            set => SetProperty(This.ReplaceIfExist, value, () => This.ReplaceIfExist = value);
        }

        public string Extensions
        {
            get => This.AcceptedExtensions;
            set => SetProperty(This.AcceptedExtensions, value, () => This.AcceptedExtensions = value);
        }

        public string Format
        {
            get => This.Format;
            set => SetProperty(This.Format, value, () => This.Format = value);
        }

    }
}
