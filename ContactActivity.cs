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
    [Activity(Label = "ContactActivity")]
    [IntentFilter(new[] { "contact" }, Categories = new[] { Intent.CategoryDefault })]
    public class ContactActivity : Activity, Android.Views.View.IOnClickListener
    {

        EditText to, subject, msg;
        Button snd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_contact);

            // Create your application here

            to = FindViewById<EditText>(Resource.Id.et1);
            subject = FindViewById<EditText>(Resource.Id.et2);
            msg = FindViewById<EditText>(Resource.Id.et3);

            snd = FindViewById<Button>(Resource.Id.btnsend);

            snd.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            if(v==snd)
            {
                String[] emails = { to.Text };
                Intent intent = new Intent(Intent.ActionSend);
                intent.SetType("text/plain");
                intent.PutExtra(Intent.ExtraEmail, emails);
                intent.PutExtra(Intent.ExtraSubject, subject.Text);
                intent.PutExtra(Intent.ExtraText, msg.Text);
                StartActivity(intent);
            }
        }
    }
}