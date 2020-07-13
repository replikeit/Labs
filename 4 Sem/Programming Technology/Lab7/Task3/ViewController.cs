using Foundation;
using System;
using CoreImage;
using UIKit;

namespace Task3
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }

        partial void GetCaloriesButton_TouchUpInside(UIButton sender)
        {
            double age = double.Parse(ageTextBox.Text);
            double height = double.Parse(heightTextBox.Text);
            double weight = double.Parse(weightTextBox.Text);

            double result = 0;
            double bmi = (weight) / (Math.Pow(height/100, 2));

            switch (sexSegment.SelectedSegment)
            {
                case 0:
                    result = (88.362 + 13.397 * weight + 3.098 * height - 4.330 * age);
                    break;
                case 1:
                    result = (447.593 + 9.247 * weight + 3.098 * height - 4.330 * age);
                    break;
                default:
                    break;
            }

            switch (trainSegment.SelectedSegment)
            {
                case 0:
                    result *= 1.2;
                    break;
                case 1:
                    result *= 1.375;
                    break;
                case 2:
                    result *= 1.55;
                    break;
                case 3:
                    result *= 1.725;
                    break;
                default:
                    break;
            }

            resultLabel.Text = $"Calories per day: {result.ToString("0.00")} kСal.\n" +
                               $"Body mass index: {bmi.ToString("0.0")}";
        }
    }
}