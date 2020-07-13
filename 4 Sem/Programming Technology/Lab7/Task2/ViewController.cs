using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Task2
{
    public partial class ViewController : UIViewController
    {
        private static Dictionary<string, TownInfo> townDic;
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        private void townPicker_Select(object sender, TownEventArgs e)
        {
            var town = townDic[e.Town];
            museumImage.Image = town.MuseumImage;
            museumNameLabel.Text = town.MuseumName;

            int temp = town.Temperature;
            tempLabel.TextColor = UIColor.Black;
            if (temp < 0)
                tempLabel.TextColor = UIColor.SystemBlueColor;
            else if (temp > 20)
                tempLabel.TextColor = UIColor.SystemRedColor;
            else if (temp > 10)
                tempLabel.TextColor = UIColor.SystemYellowColor;
           

            tempLabel.Text = temp.ToString() + "°C";
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            townDic = new Dictionary<string, TownInfo>()
            {
                { "Minsk", new TownInfo(3,
                    "Museum of the History of the Great Patriotic War",
                    UIImage.FromBundle("Minsk.jpg")) },
                { "Yerevan", new TownInfo(24,
                    "Parajanov Museum",
                    UIImage.FromBundle("Yerevan.jpg")) },
                { "Vanadzor", new TownInfo(17,
                    "Fine Arts Museum",
                    UIImage.FromBundle("Vanadzor.jpg")) },
                { "Gomel", new TownInfo(-5,
                    "Hunting lodge",
                    UIImage.FromBundle("Gomel.jpg"))}
            };
            TownsViewModel tm = new TownsViewModel(townDic);
            tm.TownChanged += townPicker_Select;
            townPicker.Model = tm;

            townPicker_Select(null, new TownEventArgs(){Town = tm.list[0]});
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }

    }
}