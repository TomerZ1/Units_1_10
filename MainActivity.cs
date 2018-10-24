using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content;
using AlertDialog = Android.App.AlertDialog;

namespace Units_1_10
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, Android.Views.View.IOnClickListener
    {

        EditText et1, et2, et3;
        Button btncam, btnsav, btnsur, btncon;
        ImageView iv;
        Android.Graphics.Bitmap bitmap;
        TextView tv;

        ISharedPreferences sp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            et1 = FindViewById<EditText>(Resource.Id.et1);
            et2 = FindViewById<EditText>(Resource.Id.et2);
            et3 = FindViewById<EditText>(Resource.Id.et3);

            iv = FindViewById<ImageView>(Resource.Id.iv);

            tv = FindViewById<TextView>(Resource.Id.tvAvg);

            btncam = FindViewById<Button>(Resource.Id.btn1);
            btnsav = FindViewById<Button>(Resource.Id.btn2);
            btnsur = FindViewById<Button>(Resource.Id.btn3);
            btncon = FindViewById<Button>(Resource.Id.btn4);

            btncam.SetOnClickListener(this);
            btnsav.SetOnClickListener(this);
            btnsur.SetOnClickListener(this);
            btncon.SetOnClickListener(this);

            sp = this.GetSharedPreferences("details", Android.Content.FileCreationMode.Private);

            string avg = Intent.GetStringExtra("average");
            tv.Text = "Average rating is: " + avg;

        }

        public void OnClick(View v)
        {
            if (v == btncam)
            {
                Intent intent = new Intent(Android.Provider.MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            }
            else if (v == btnsav)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Save");
                builder.SetMessage("Are you sure you want to save?");
                builder.SetCancelable(true);
                builder.SetPositiveButton("Save", OkAction);
                builder.SetNegativeButton("Cancel", CancelAction);

                AlertDialog dialog = builder.Create();
                dialog.Show();
            }
            else if (v == btnsur)
            {
                Intent intent = new Intent("survey");
                StartActivity(intent);
            }
            else if (v == btncon)
            {
                Intent intent = new Intent("contact");
                StartActivity(intent);
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 0)//from camera
            {
                if (resultCode == Result.Ok)
                {
                    bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
                    iv.SetImageBitmap(bitmap);
                }
            }
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            int price = int.Parse(et3.Text.ToString());
            Android.Content.ISharedPreferencesEditor editor = sp.Edit(); //permission
            editor.PutString("computer_name", et1.Text);
            editor.PutString("store_name", et2.Text);
            editor.PutInt("price", price);
            editor.Commit();
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {}

    }
}