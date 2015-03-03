using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Unvired.Kernel.Login;
using Unvired.Kernel.Database;
using System.Reflection;
using System.IO;
using System.Xml.Linq;
using Unvired.Kernel.Util;
using Unvired.Kernel.Log;
using Unvired.Kernel.UI;

namespace AndroidSample
{
    [Activity(Label = "Unvired Sample", Theme = "@style/Theme.Splash", MainLauncher = true, Icon = "@drawable/AppIcon", NoHistory = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : Activity, LoginListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            LoginParameters.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString();
            LoginParameters.AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            LoginParameters.Url = "live.unvired.io/UNI";
            LoginParameters.AppTitle = "Unvired Sample";
            LoginParameters.AppName = "UNVIRED_HELLO_WORLD";
            LoginParameters.showCompany = true;
            
            LoginParameters.Protocol = LoginParameters.PROTOCOL.https;
            LoginParameters.LoginTypes = new LoginParameters.LOGIN_TYPE[] { LoginParameters.LOGIN_TYPE.UNVIRED_ID, LoginParameters.LOGIN_TYPE.ADS, LoginParameters.LOGIN_TYPE.SAP };

            LoginParameters.DeviceType = LoginParameters.DEVICE_TYPE.ANDROID_PHONE;
            LoginParameters.LoginListener = this;
            
            using (StreamReader sr = new StreamReader(Assets.Open("MetaData.xml")))
            {
                string content = sr.ReadToEnd();
                LoginParameters.MetaDataXml = XDocument.Parse(content);
            }

            //To support SQLCipher add SQLCipher component into project and set EncryptDataBase ti true
           // LoginParameters.EncryptDataBase = true;

            Util.InitializeNative(this);

            //Now call Unvired Authentication service
            AuthenticationService.Login();
        }

         //Login call back from Unvired Component dll

        public void AuthenticateAndActivationSuccessful()
        {
            NavigateToHelloWorldScreen();
        }
        public void LoginSuccessful()
        {
            NavigateToHelloWorldScreen();
        }

        public void AuthenticateAndActivationFailure(string errorMessage){}
        public void LoginFailure(string errorMessage){}
        public void DemologinSuccessful() { }
        public void LoginCancelled() { }
        public void InvokeLoginScreen(bool isSuccessiveLogin) { }

        //On successful login navigate to application home screen
        private void NavigateToHelloWorldScreen()
        {
            var intent = new Intent(this, typeof(HelloWorldScreen));
            StartActivity(intent);
            this.Finish();
        }
       
    }
}

