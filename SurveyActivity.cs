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

namespace Units_1_10
{
    [Activity(Label = "SurveyActivity")]
    [IntentFilter(new[] { "survey" }, Categories = new[] {Intent.CategoryDefault })]
    public class SurveyActivity : Activity, SeekBar.IOnSeekBarChangeListener
    {
        Switch sw;
        SeekBar sb1, sb2;
        TextView tv1, tv2;
        Button btn;
        int num = 0;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_survey);
            // Create your application here

            tv1 = FindViewById<TextView>(Resource.Id.tv1);
            tv2 = FindViewById<TextView>(Resource.Id.tv2);

            sb1 = FindViewById<SeekBar>(Resource.Id.sb1);
            sb2 = FindViewById<SeekBar>(Resource.Id.sb2);

            sw = FindViewById<Switch>(Resource.Id.sw);

            btn=FindViewById<Button>(Resource.Id.btn);

            sb1.SetOnSeekBarChangeListener(this);
            sb2.SetOnSeekBarChangeListener(this);

            sw.CheckedChange += Sw_CheckedChange;
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);    
            builder.SetTitle("End Survey");
            builder.SetMessage("End survey and go back");
            builder.SetCancelable(true);
            builder.SetPositiveButton("Yes", OkAction);
            builder.SetNegativeButton("Cancel", CancelAction);
            AlertDialog dialog = builder.Create();
            dialog.Show();
        }

        private void Sw_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                num = 10;
            else
                num = 0;
        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            if (seekBar==sb1)
            {
                tv1.Text = (progress/10).ToString();
            }
            else if (seekBar==sb2)
            {
                tv2.Text = (progress/10).ToString();
            }
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            string avg = ((sb1.Progress / 10 + sb2.Progress / 10 + num) / 3).ToString();
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("average", avg);
            StartActivity(intent);
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
        }


    }
}