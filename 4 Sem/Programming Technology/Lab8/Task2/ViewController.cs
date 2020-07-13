using Foundation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using AudioUnit;
using CoreGraphics;
using UIKit;

using Xamarin.Utils;

namespace Task2
{
    public partial class ViewController : UIViewController
    {
        private bool isBlink = false;

        private CGPoint[] trianglePath = new CGPoint[]
        {
            new CGPoint(120,550),
            new CGPoint(240,430),
            new CGPoint(340,460)
        };

        private CGPoint[] decagonPath = new CGPoint[]
        {
            new CGPoint(170,230),
            new CGPoint(230,230),
            new CGPoint(270,270),
            new CGPoint(285,330),
            new CGPoint(270,390),
            new CGPoint(230,430),
            new CGPoint(170,430),
            new CGPoint(130,390),
            new CGPoint(115,330),
            new CGPoint(130,270),
        };
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            DrawingPlace.Image = DrawTriangle();
            shareSegment.ValueChanged += shareSegment_ValueChanged;

            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(OnTap);
            DrawingPlace.AddGestureRecognizer(tapGesture);

            UIRotationGestureRecognizer rotationGesture = new UIRotationGestureRecognizer(OnRotation);
            DrawingPlace.AddGestureRecognizer(rotationGesture);

            UISwipeGestureRecognizer swipeGesture = new UISwipeGestureRecognizer(OnSwipe);
            DrawingPlace.AddGestureRecognizer(swipeGesture);

            UIPinchGestureRecognizer pinchGesture = new UIPinchGestureRecognizer(OnPinch);
            DrawingPlace.AddGestureRecognizer(pinchGesture);

            UILongPressGestureRecognizer longPressGesture = new UILongPressGestureRecognizer(OnLongPress);
            DrawingPlace.AddGestureRecognizer(longPressGesture);
        }

        void OnTap(UITapGestureRecognizer tap)
        {
            MainFrame.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("bg1.jpg"));
            DrawingPlace.Transform = CGAffineTransform.MakeRotation(0f);
            UIView.Animate(1, 1, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeTranslation(0f, 150f);

                },
                null
            );
            UIView.Animate(2, 2, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeTranslation(0f, 0f);

                },
                null
            );

            UIView.Animate(1, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeRotation((3.14159f * 180 / 180f));

                },
                null
            );
            UIView.Animate(2, 0.5, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeRotation(3.14159f * 360 / 180f);

                },
                null
            );

            
           
        }

        void OnRotation(UIRotationGestureRecognizer rot)
        {
            MainFrame.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("bg2.jpg"));
        }

        void OnSwipe(UISwipeGestureRecognizer rot)
        {
            MainFrame.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("bg5.jpg"));
        }

        void OnPinch(UIPinchGestureRecognizer pinch)
        {
            MainFrame.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("bg3.jpg"));
        }

        void OnLongPress(UILongPressGestureRecognizer longPress)
        {
            MainFrame.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("bg4.jpg"));
        }



        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }



        UIImage DrawTriangle()
        {
            UIGraphics.BeginImageContext(DrawingPlace.Frame.Size);

            using (CGContext g = UIGraphics.GetCurrentContext())
            {

                g.SetLineWidth(4);
                UIColor.Black.SetStroke();

                var path = new CGPath();
             
                path.AddLines(trianglePath);

                path.CloseSubpath();

                g.AddPath(path);
                g.Clip();

                CGColorSpace rgb = CGColorSpace.CreateDeviceRGB();
                CGGradient gradient = new CGGradient(rgb, new CGColor[] {
                    UIColor.Blue.CGColor,
                    UIColor.Yellow.CGColor
                });

                // draw a linear gradient
                g.DrawLinearGradient(
                    gradient,
                    new CGPoint(path.BoundingBox.Left, path.BoundingBox.Top),
                    new CGPoint(path.BoundingBox.Right, path.BoundingBox.Bottom),
                    CGGradientDrawingOptions.DrawsBeforeStartLocation);

                g.DrawPath(CGPathDrawingMode.FillStroke);
            }

            return UIGraphics.GetImageFromCurrentImageContext();
        }

        UIImage DrawMutation()
        {
             UIGraphics.BeginImageContext(DrawingPlace.Frame.Size);

            using (CGContext g = UIGraphics.GetCurrentContext())
            {

                g.SetLineWidth(4);
                UIColor.Purple.SetFill();
                UIColor.Red.SetStroke();
                g.SetShadow(new CGSize(100,100),100, CGColor.CreateSrgb(0,0,0,1) );

                var path = new CGPath();

                Random rnd = new Random();
                List<CGPoint> list = new List<CGPoint>();
                for (int i = 0; i < decagonPath.Length; i++)
                {
                    list.Add(decagonPath[rnd.Next(decagonPath.Length - 1)]);
                }
                for (int i = 0; i < trianglePath.Length; i++)
                {
                    list.Add(trianglePath[rnd.Next(trianglePath.Length - 1)]);
                }

                path.AddLines(list.ToArray());
                path.CloseSubpath();
                g.AddPath(path);
                g.DrawPath(CGPathDrawingMode.FillStroke);
            }

            return UIGraphics.GetImageFromCurrentImageContext();
        }

        UIImage DrawDecagon()
        {

            UIGraphics.BeginImageContext(DrawingPlace.Frame.Size);

            using (CGContext g = UIGraphics.GetCurrentContext())
            {
                g.SetLineWidth(4);
                UIColor.Purple.SetFill();
                UIColor.Black.SetStroke();
                var path = new CGPath();

                path.AddLines(decagonPath);

                path.CloseSubpath();

                g.AddPath(path);
                g.DrawPath(CGPathDrawingMode.FillStroke);

            }

            return UIGraphics.GetImageFromCurrentImageContext();
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);


        }

        private void shareSegment_ValueChanged(object sender, EventArgs e)
        {
            switch ((sender as UISegmentedControl).SelectedSegment)
            {
                case 0:
                    DrawingPlace.Image = DrawTriangle();
                    break;
                case 1:
                    DrawingPlace.Image = DrawDecagon();
                    break;
                case 2:
                    DrawingPlace.Image = DrawMutation();
                    break;
            }
        }

        partial void RotateButton_TouchUpInside(UIButton sender)
        {
            DrawingPlace.Transform = CGAffineTransform.MakeRotation(0);

            UIView.Animate(1, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeRotation((3.14159f * 180 / 180f));
                },
                null
            );

            UIView.Animate(2, 0.5, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeRotation(3.14159f * 360 / 180f);
                },
                null
            );

        }

        partial void MoveButton_TouchUpInside(UIButton sender)
        {
            UIView.Animate(1, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeTranslation(75, 100f);

                },
                null
            );

            UIView.Animate(0.5, 1, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeTranslation(-75f, -100f);
                },
                null
            );

            UIView.Animate(2, 1.5, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeTranslation(0f, 0f);
                },
                null
            );
        }

        partial void ScalingButton_TouchUpInside(UIButton sender)
        {
            UIView.Animate(1, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeScale(1.5f, 1.5f);
                },
                null
            );

            UIView.Animate(1, 1, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeScale(0.5f, 0.5f);
                },
                null
            );

            UIView.Animate(2, 2, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    DrawingPlace.Transform = CGAffineTransform.MakeScale(1f, 1f);
                },
                null
            );
        }

        partial void TransparencyButton_TouchUpInside(UIButton sender)
        {
            if (isBlink)
            {
                DrawingPlace.Layer.RemoveAllAnimations();
                DrawingPlace.Alpha = 1f;
            }
            else
                UIView.Animate(1, 0,  UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Autoreverse,
                    () =>
                    {
                        DrawingPlace.Alpha = 0.1f;
                    },
                    null
                );
            isBlink = !isBlink;
        }
    }
}