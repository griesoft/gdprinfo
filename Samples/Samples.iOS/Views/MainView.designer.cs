// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace Samples.iOS.Views
{
    [Register ("MainView")]
    partial class MainView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel countryName_lbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel countryNumber_lbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel isInEea_lbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel isoCountryCode_lbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel longCountryCode_lbl { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (countryName_lbl != null) {
                countryName_lbl.Dispose ();
                countryName_lbl = null;
            }

            if (countryNumber_lbl != null) {
                countryNumber_lbl.Dispose ();
                countryNumber_lbl = null;
            }

            if (isInEea_lbl != null) {
                isInEea_lbl.Dispose ();
                isInEea_lbl = null;
            }

            if (isoCountryCode_lbl != null) {
                isoCountryCode_lbl.Dispose ();
                isoCountryCode_lbl = null;
            }

            if (longCountryCode_lbl != null) {
                longCountryCode_lbl.Dispose ();
                longCountryCode_lbl = null;
            }
        }
    }
}