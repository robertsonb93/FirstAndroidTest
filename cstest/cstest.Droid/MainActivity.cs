using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace cstest.Droid
{
	[Activity (Label = "cstest.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            SetContentView(Resource.Layout.Main);

            MyClass mc = new MyClass();
            FindViewById<TextView>(Resource.Id.st).Text = mc.Thing1;
            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += Button_Click;
		}
        private async void Button_Click(object sender, EventArgs e)
        {
            MyClass mc = new MyClass();
            count = (count +1)%2;
            if(count == 1)
                FindViewById<TextView>(Resource.Id.st).Text = mc.Thing1;
            else
                FindViewById<TextView>(Resource.Id.st).Text = mc.thing2;
        }
	}
}


