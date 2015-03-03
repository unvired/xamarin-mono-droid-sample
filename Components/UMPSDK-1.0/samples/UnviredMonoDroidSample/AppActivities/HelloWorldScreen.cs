using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System.Threading.Tasks;
using Unvired.Kernel.Database;
using Unvired.Kernel.Core;
using Entity;
using Unvired.Kernel.Log;
using Unvired.Kernel.Login;
using Unvired.Kernel.Model;
using Unvired.Kernel.Sync;
using UnviredMonoDroidSample;

namespace AndroidSample
{
    [Activity(Label = "Unvired Sample", Icon = "@drawable/logo", Theme = "@android:style/Theme.DeviceDefault.Light", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class HelloWorldScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HelloWorldScreen);
        }

    }
}