// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace code_test.iOS.Views
{
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		UIKit.UIButton LogInButton { get; set; }

		[Outlet]
		UIKit.UITextField PasswordLabel { get; set; }

		[Outlet]
		UIKit.UIButton SignUpButton { get; set; }

		[Outlet]
		UIKit.UITextField UsernameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (UsernameLabel != null) {
				UsernameLabel.Dispose ();
				UsernameLabel = null;
			}

			if (PasswordLabel != null) {
				PasswordLabel.Dispose ();
				PasswordLabel = null;
			}

			if (LogInButton != null) {
				LogInButton.Dispose ();
				LogInButton = null;
			}

			if (SignUpButton != null) {
				SignUpButton.Dispose ();
				SignUpButton = null;
			}
		}
	}
}
