using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Linq;
using NRGScoutingApp2020.PageTemplete;

namespace NRGScoutingApp2020.Droid
{
    [Activity(Label = "NRGScoutingApp2020", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            AppCenter.Start(System.Environment.GetEnvironmentVariable("APPCENTER_SECRET_KEY"), typeof(Analytics), typeof(Crashes));

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
            }

            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 16908332)
            {
                var currentPage = Xamarin.Forms.Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault() as AlertableContentPage;
                if (currentPage?.backAction != null)
                {
                    currentPage?.backAction.Invoke();
                    return false;
                }
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            var currentPage = Xamarin.Forms.Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault() as AlertableContentPage;
            if (currentPage?.backAction != null)
            {
                currentPage?.backAction.Invoke();
                return;
            }
            base.OnBackPressed();
        }
    }
}