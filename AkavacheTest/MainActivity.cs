using Android.App;
using Android.Widget;
using Android.OS;
using Akavache;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Collections.Generic;

using System.Reactive.Linq;

namespace AkavacheTest
{
    [Activity(Label = "AkavacheTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            BlobCache.ApplicationName = "AkavacheText";
            string json = @"{ 'Username': 'Mike','Password': 'Ma'}"; 
            SetContentView(Resource.Layout.Main);
            var getData = JsonConvert.DeserializeObject<User>(json);

            await BlobCache.LocalMachine.InsertObject("MikeMa", getData);
            var myuser = await BlobCache.LocalMachine.GetObject<User>("MikeMa");
            System.Console.WriteLine(myuser.Username+"---"+myuser.Password);

        }
     }
    public class User
    {
      public  string Username { get; set; }
      public string   Password { get; set; }
    }
}

