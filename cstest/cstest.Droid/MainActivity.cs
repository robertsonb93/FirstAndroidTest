using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;

namespace cstest.Droid
{
	[Activity (Label = "cstest.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, ISensorEventListener
	{
        static readonly object _syncLock = new object();
        SensorManager _sensorManager;
        TextView _sensorTextView;
        int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            SetContentView(Resource.Layout.Main);

            MyClass mc = new MyClass();
            FindViewById<TextView>(Resource.Id.st).Text = mc.Thing1;
            Button button = FindViewById<Button>(Resource.Id.myButton);

            _sensorManager = (SensorManager)GetSystemService(Context.SensorService);
            _sensorTextView = FindViewById<TextView>(Resource.Id.xx_Text);

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

        protected override void OnResume()
        {
            base.OnResume();
            _sensorManager.RegisterListener(this,
                                            _sensorManager.GetDefaultSensor(SensorType.Accelerometer),
                                            SensorDelay.Ui);
        }

        protected override void OnPause()
        {
            base.OnPause();
            _sensorManager.UnregisterListener(this);
        }

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
            // We don't want to do anything here.
        }

        public void OnSensorChanged(SensorEvent e)
        {
            lock (_syncLock)
            {
                _sensorTextView.Text = string.Format("x={0:f}, y={1:f}, z={2:f}", e.Values[0], e.Values[1], e.Values[2]);
            }
        }


    }
}


