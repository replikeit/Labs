using Foundation;
using System;
using UIKit;

namespace Task4
{
    public partial class ViewController : UIViewController
    {
        private bool isMath = true;
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            pendulumTypeSegment.ValueChanged += delegate
            {
                isMath = !isMath;
                valueTypeLabel.Text = isMath? "Length" : "Weight" ;
            };
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }

        partial void CalculateButton_TouchUpInside(UIButton sender)
        {
            double val = double.Parse(valueTextBox.Text);

            double result = 0;
            switch (pendulumTypeSegment.SelectedSegment)
            {
                case 0:
                    result = 2 * Math.PI * Math.Sqrt(val / 9.81);
                    break;
                case 1:
                    result = 2 * Math.PI * Math.Sqrt(val / 100);
                    break;
                default:
                    break;
            }

            periodLabel.Text = $"Period = {result.ToString("0.00")} с";
        }
    }
}