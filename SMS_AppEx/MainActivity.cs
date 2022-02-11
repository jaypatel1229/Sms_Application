using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SMS_AppEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btn;
        private EditText edtTxt;
        private TextView txtv1;
        private string recipient;
        private string messageText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            edtTxt = FindViewById<EditText>(Resource.Id.edt1);
            btn = FindViewById<Button>(Resource.Id.bt1);
            txtv1 = FindViewById<TextView>(Resource.Id.tv1);


            btn.Click += SendButton_Click;

        }

        private  void SendButton_Click(object sender, EventArgs e)
        {

            var res = new SmsMessage(edtTxt.Text, new string[] { recipient });
            Sms.ComposeAsync(res);

            

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}