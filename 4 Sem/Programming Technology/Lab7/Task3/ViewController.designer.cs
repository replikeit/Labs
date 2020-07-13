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

namespace Task3
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ageTextBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton getCaloriesButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField heightTextBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel resultLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl sexSegment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl trainSegment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField weightTextBox { get; set; }

        [Action ("GetCaloriesButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GetCaloriesButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ageTextBox != null) {
                ageTextBox.Dispose ();
                ageTextBox = null;
            }

            if (getCaloriesButton != null) {
                getCaloriesButton.Dispose ();
                getCaloriesButton = null;
            }

            if (heightTextBox != null) {
                heightTextBox.Dispose ();
                heightTextBox = null;
            }

            if (resultLabel != null) {
                resultLabel.Dispose ();
                resultLabel = null;
            }

            if (sexSegment != null) {
                sexSegment.Dispose ();
                sexSegment = null;
            }

            if (trainSegment != null) {
                trainSegment.Dispose ();
                trainSegment = null;
            }

            if (weightTextBox != null) {
                weightTextBox.Dispose ();
                weightTextBox = null;
            }
        }
    }
}