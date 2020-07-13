using Foundation;
using System;
using System.Drawing;
using UIKit;

namespace Task1
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            bgChangeSwitch.ValueChanged += bgChangeSwitch_ValueChanged;
            bgChangeSwitch_ValueChanged(null,null);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void bgChangeSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (!bgChangeSwitch.On)
            {
                imgNameLabel.Text = "bg1.jpg";
                mainForm.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("bg1.jpg"));
            }
            else
            {
                imgNameLabel.Text = "bg2.jpg";
                mainForm.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("bg2.jpg"));
            }
        }
    }
}