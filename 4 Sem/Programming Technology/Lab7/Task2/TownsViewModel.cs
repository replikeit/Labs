using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Task2
{
    class TownEventArgs : EventArgs
    {
        public string Town { get; set; }
    }

    class TownsViewModel : UIPickerViewModel
    {
        public string[] list;
        public delegate void TownEventHandle(object sender, TownEventArgs e);
        public event TownEventHandle TownChanged;

        public TownsViewModel(Dictionary<string, TownInfo> dic)
        {
            list = new string[dic.Count];
            int i = 0;
            foreach (var val in dic)
            {
                list[i] = val.Key;
                i++;
            }
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return list.Length;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return list[(int) row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            TownChanged?.Invoke(this, new TownEventArgs(){Town = list[(int)row]});
        }
    }
}