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

namespace Task1
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView DrawingPlace { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton greenColorButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider penWidthSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton redColorButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton savePicButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton yellowColorButton { get; set; }

        [Action ("GreenColorButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GreenColorButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("RedColorButton_TouchUpInside")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void RedColorButton_TouchUpInside ();

        [Action ("RedColorButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void RedColorButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton11520_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void savePicButton_TouchUpInside(UIKit.UIButton sender);

        [Action ("YellowColorButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void YellowColorButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (DrawingPlace != null) {
                DrawingPlace.Dispose ();
                DrawingPlace = null;
            }

            if (greenColorButton != null) {
                greenColorButton.Dispose ();
                greenColorButton = null;
            }

            if (penWidthSlider != null) {
                penWidthSlider.Dispose ();
                penWidthSlider = null;
            }

            if (redColorButton != null) {
                redColorButton.Dispose ();
                redColorButton = null;
            }

            if (savePicButton != null) {
                savePicButton.Dispose ();
                savePicButton = null;
            }

            if (yellowColorButton != null) {
                yellowColorButton.Dispose ();
                yellowColorButton = null;
            }
        }
    }
}