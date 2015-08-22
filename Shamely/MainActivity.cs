using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Shamely
{
	[Activity (Label = "Shamely", MainLauncher = true, Icon = "@drawable/icon")]
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
			Button addFood = FindViewById<Button> (Resource.Id.AddFoodButton);

			addFood.Click += delegate(object sender, EventArgs e) {
				var intent = new Intent(this, typeof(AddFoodActivity)); 	 
			};
		}
	}
}


