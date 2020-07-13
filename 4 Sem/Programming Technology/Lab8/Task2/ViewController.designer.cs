// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Task2
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView DrawingPlace { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MainFrame { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MoveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RotateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ScalingButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl shareSegment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TransparencyButton { get; set; }

        [Action ("MoveButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MoveButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("RotateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void RotateButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("ScalingButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ScalingButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("TransparencyButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TransparencyButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (DrawingPlace != null) {
                DrawingPlace.Dispose ();
                DrawingPlace = null;
            }

            if (MainFrame != null) {
                MainFrame.Dispose ();
                MainFrame = null;
            }

            if (MoveButton != null) {
                MoveButton.Dispose ();
                MoveButton = null;
            }

            if (RotateButton != null) {
                RotateButton.Dispose ();
                RotateButton = null;
            }

            if (ScalingButton != null) {
                ScalingButton.Dispose ();
                ScalingButton = null;
            }

            if (shareSegment != null) {
                shareSegment.Dispose ();
                shareSegment = null;
            }

            if (TransparencyButton != null) {
                TransparencyButton.Dispose ();
                TransparencyButton = null;
            }
        }
    }
}