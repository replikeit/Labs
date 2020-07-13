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
        UIKit.UIImageView museumImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel museumNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel tempLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView townPicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (museumImage != null) {
                museumImage.Dispose ();
                museumImage = null;
            }

            if (museumNameLabel != null) {
                museumNameLabel.Dispose ();
                museumNameLabel = null;
            }

            if (tempLabel != null) {
                tempLabel.Dispose ();
                tempLabel = null;
            }

            if (townPicker != null) {
                townPicker.Dispose ();
                townPicker = null;
            }
        }
    }
}