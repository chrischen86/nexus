using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;

namespace Nexus.Droid
{
	[Activity (Label = "Nexus.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);

            var myClass = new MyClass();
			button.Click += async delegate
            {
                var result = await myClass.TestGet();
                var list = result.ToList();
                button.Text = string.Format("{0} clicks! {1}", count++, String.Join(", ", list.Select(x => x.Name)));
            };
		}
	}
}


