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
        UIKit.UISwitch bgChangeSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel imgNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView mainForm { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bgChangeSwitch != null) {
                bgChangeSwitch.Dispose ();
                bgChangeSwitch = null;
            }

            if (imgNameLabel != null) {
                imgNameLabel.Dispose ();
                imgNameLabel = null;
            }

            if (mainForm != null) {
                mainForm.Dispose ();
                mainForm = null;
            }
        }
    }
}