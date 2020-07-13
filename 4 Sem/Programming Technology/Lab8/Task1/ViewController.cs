using Foundation;
using System;
using CoreGraphics;
using UIKit;

namespace Task1
{
    public partial class ViewController : UIViewController
    {
        private CGPoint lastPoint;
        private int i = 0;
        private CGContext g;
        private float width = 5;
        private UIColor color = UIColor.Red;

        public ViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            penWidthSlider.ValueChanged += penWidthSlider_Change;
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            UIGraphics.EndImageContext();
            var touch = (UITouch)touches.AnyObject;

            lastPoint = touch.LocationInView(DrawingPlace);
            UIGraphics.BeginImageContext(DrawingPlace.Frame.Size);
            g = UIGraphics.GetCurrentContext();
            g.SetLineWidth(width);
            g.SetLineCap(CGLineCap.Round);
            color.SetStroke();
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            var touch = (UITouch)touches.AnyObject;
            var currentPoint = touch.LocationInView(DrawingPlace);

            CGRect rect = new CGRect(0d, 0d, this.View.Frame.Size.Width, this.View.Frame.Size.Height);
            DrawingPlace.DrawRect(rect, new UIViewPrintFormatter());

            g.BeginPath();
            g.MoveTo(lastPoint.X, lastPoint.Y);
            g.AddLineToPoint(currentPoint.X, currentPoint.Y);
            g.StrokePath();
            DrawingPlace.Image = UIGraphics.GetImageFromCurrentImageContext();
            lastPoint = currentPoint;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        private void penWidthSlider_Change(object sender, EventArgs e)
        {
            if (sender != null)
            {
                width = (sender as UISlider).Value * 25;
            }
        }

        private void ChangeColor(UIButton sender)
        {
            switch (sender.Tag)
            {
                case 1:
                    color = UIColor.Red;
                    break;
                case 2:
                    color = UIColor.Green;
                    break;
                case 3:
                    color = UIColor.Blue;
                    break;
            }
        }

        partial void RedColorButton_TouchUpInside(UIButton sender)
        {
           ChangeColor(sender);
        }

        partial void GreenColorButton_TouchUpInside(UIButton sender)
        {
            ChangeColor(sender);
        }

        partial void YellowColorButton_TouchUpInside(UIButton sender)
        {
            ChangeColor(sender);
        }

        private void GetSaveStatus(UIImage image, NSError error)
        {
            if (error != null)
            {
                var okAlertController = UIAlertController.Create("Error", "The image was not saved.", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            else
            {
                var okAlertController = UIAlertController.Create("Success", "The image was saved at the gallery.", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
        }

        partial void savePicButton_TouchUpInside(UIButton sender)
        {
            DrawingPlace.Image.SaveToPhotosAlbum(GetSaveStatus);
        }
    }
}