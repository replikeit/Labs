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

namespace Lab1
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Label1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView mainForm { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch slider1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextBox1 { get; set; }

        [Action ("UIButton220_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton220_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Label1 != null) {
                Label1.Dispose ();
                Label1 = null;
            }

            if (mainForm != null) {
                mainForm.Dispose ();
                mainForm = null;
            }

            if (slider1 != null) {
                slider1.Dispose ();
                slider1 = null;
            }

            if (TextBox1 != null) {
                TextBox1.Dispose ();
                TextBox1 = null;
            }
        }
    }
}