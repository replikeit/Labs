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

namespace Task4
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton calculateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl pendulumTypeSegment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel periodLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField valueTextBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel valueTypeLabel { get; set; }

        [Action ("CalculateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CalculateButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (calculateButton != null) {
                calculateButton.Dispose ();
                calculateButton = null;
            }

            if (pendulumTypeSegment != null) {
                pendulumTypeSegment.Dispose ();
                pendulumTypeSegment = null;
            }

            if (periodLabel != null) {
                periodLabel.Dispose ();
                periodLabel = null;
            }

            if (valueTextBox != null) {
                valueTextBox.Dispose ();
                valueTextBox = null;
            }

            if (valueTypeLabel != null) {
                valueTypeLabel.Dispose ();
                valueTypeLabel = null;
            }
        }
    }
}