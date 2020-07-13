using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Task2
{
    class TownInfo
    {
        public int Temperature { get; }
        public string MuseumName { get; }
        public UIImage MuseumImage { get; }

        public TownInfo(int temperature, string museumName, UIImage museumImage)
        {
            Temperature = temperature;
            MuseumName = museumName;
            MuseumImage = museumImage;
        }
    }
}