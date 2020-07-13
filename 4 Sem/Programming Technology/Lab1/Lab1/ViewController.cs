using Foundation;
using System;
using UIKit;

namespace Lab1
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            slider1.ValueChanged += delegate
            {
                Label1.Text = slider1.On.ToString();
            };
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void UIButton220_TouchUpInside(UIButton sender)
        {
            
        }
    }
}