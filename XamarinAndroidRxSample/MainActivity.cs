using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

using System.Reactive.Linq; // これ必要

namespace XamarinAndroidRxSample
{
    [Activity (Label = "XamarinAndroidRxSample", MainLauncher = true)]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
			
            button.Click += delegate
            {
                Observable.Range(0, 10) // 0〜9 のリスト
                .Where(n => n % 2 == 0) // 偶数だけ抽出
                .Select(n => n * 2) // 値を２倍して
                .Subscribe(n => Log.Debug("Activity1", n.ToString())); // 出力
            };
        }
    }
}


