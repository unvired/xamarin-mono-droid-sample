using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Unvired.Kernel.Login;
using Unvired.Kernel.Database;
using System.Reflection;
using System.Xml.Linq;
using IPhoneApplication;
using Unvired.Kernel.Log;
using Unvired.Kernel.Util;
using System.IO;

namespace UnviredIOSSample
{

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate, LoginListener
	{
		// class-level declarations
		UIWindow window;

		public void AuthenticateAndActivationFailure (string errorMessage){}

		public void AuthenticateAndActivationSuccessful ()
		{
			displayHomeScreen ();
		}

		public void DemologinSuccessful (){}

		public void InvokeLoginScreen (bool isSuccessiveLogin){}

		public void LoginCancelled (){}

		public void LoginFailure (string errorMessage){}

		public void LoginSuccessful ()
		{
			displayHomeScreen ();
		}

		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			// Call Login API
			LoginParameters.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString();
			LoginParameters.AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

			LoginParameters.AppTitle = "Unvired Sample";
			LoginParameters.AppName = "UNVIRED_HELLO_WORLD";
			LoginParameters.showCompany = true;

			LoginParameters.LoginTypes = new LoginParameters.LOGIN_TYPE[] { LoginParameters.LOGIN_TYPE.UNVIRED_ID, LoginParameters.LOGIN_TYPE.ADS, LoginParameters.LOGIN_TYPE.SAP };

			LoginParameters.DeviceType = LoginParameters.DEVICE_TYPE.iPhone;
			LoginParameters.LoginListener = this;

			LoginParameters.LoginTypes = new LoginParameters.LOGIN_TYPE[] {
				LoginParameters.LOGIN_TYPE.UNVIRED_ID,
				LoginParameters.LOGIN_TYPE.ADS,
				LoginParameters.LOGIN_TYPE.SAP
			};
			LoginParameters.CurrentLoginType = LoginParameters.LOGIN_TYPE.UNVIRED_ID;

			LoginParameters.Url = "http://live.unvired.io/UNI";
	
			// Pass in the Metadata.xml file
			string content = System.IO.File.ReadAllText ("MetaData.xml");
			LoginParameters.MetaDataXml = XDocument.Parse (content);

			Util.InitializeNative(window);

			//Fuction To check App installation
			AuthenticationService.Login ();

			return true;
		}

		public void displayHomeScreen ()
		{
			HomeViewController homeViewController = new HomeViewController ();
			UINavigationController navigationController = new UINavigationController (homeViewController);
			window.RootViewController = navigationController;
			window.MakeKeyAndVisible ();
		}
	}
}