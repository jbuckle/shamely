using System;
using System.IO;

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
		private string listChoice = "";
		private string[] choices = new string[] { "A healthy choice", 
			"An okay choice", 
			"A bad choice"};

		private AlertDialog addFoodDialog = null;
		private AlertDialog confirmFoodDialog = null;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button addFood = FindViewById<Button> (Resource.Id.AddFoodButton);

			addFood.Click += (object sender, EventArgs e) => 
			{
				AlertDialog.Builder addFoodDialogBuilder = new AlertDialog.Builder(this);
				addFoodDialogBuilder.SetTitle ("I had something to eat and it was:");
				addFoodDialogBuilder.SetSingleChoiceItems (choices, 0, clickFoodDialogList);

				addFoodDialog = addFoodDialogBuilder.Create();

				// Show the alert dialog to the user and wait for response.
				addFoodDialog.Show();
			};
		}

		private void clickFoodDialogList(object sender, DialogClickEventArgs args){
			listChoice = choices [args.Which];

			// Open a confirmation alert 
			AlertDialog.Builder confirmFoodDialogBuilder = new AlertDialog.Builder(this);
			confirmFoodDialogBuilder.SetTitle ("Confirm selection");

			confirmFoodDialogBuilder.SetMessage ("You are adding the following choice: " +
			listChoice + ".  Do you wish to proceed?");

			// Insert the selection into the database on confirmation
			confirmFoodDialogBuilder.SetPositiveButton ("Confirm", delegate { 
				dismissAddFoodDialog ();
			});

			// Close all alerts if the user cancels at this point
			confirmFoodDialogBuilder.SetNegativeButton ("Cancel", delegate { 
				dismissAddFoodDialog ();
			});

			confirmFoodDialog = confirmFoodDialogBuilder.Create ();
			confirmFoodDialog.Show ();
		}
	
		private void dismissAddFoodDialog() {
			if (addFoodDialog.IsShowing) {
				addFoodDialog.Dismiss ();
			}
		}
	}
}