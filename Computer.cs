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
    class Computer
    {
        private string name;
        private string store;
        private int price;
        private ImageView iv;

        public Computer(string name, string store, int price, ImageView iv)
        {
            this.name = name;
            this.store = store;
            this.price = price;
            this.iv = iv;
        }

        public int MyProperty { get; set; }

    }
}