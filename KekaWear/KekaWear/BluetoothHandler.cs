using Android.App;
using Android.OS;
using Android.Widget;
using System.Text;
using KekaWear.Models.Xhr.Core;
using Newtonsoft.Json;

namespace KekaWear
{
    public class BluetoothHandler : Handler
    {
        Activity activity;
        public BluetoothHandler(Activity frag)
        {
            activity = frag;

        }
        public override void HandleMessage(Message msg)
        {
            switch (msg.What)
            {
                case (int)BluetoothState.Change:
                    switch ((ConnectionState)msg.Arg1)
                    {
                        case ConnectionState.Connected:
                            Toast.MakeText(Application.Context, "Connection Successful", ToastLength.Long).Show();
                            break;
                        case ConnectionState.None:
                        case ConnectionState.Listen:
                        case ConnectionState.Connecting:
                            Toast.MakeText(Application.Context, "Activity Not Works Due to Connection State : " + (ConnectionState)msg.Arg1, ToastLength.Long).Show();
                            break;
                    }
                    break;
                case (int)BluetoothState.Write:
                    var writeBuffer = (byte[])msg.Obj;
                    var writeMessage = Encoding.ASCII.GetString(writeBuffer);
                    break;
                case (int)BluetoothState.Read:
                    var readBuffer = (byte[])msg.Obj;
                    BluetoothManager.result = Encoding.ASCII.GetString(readBuffer);
                    break;
                case (int)BluetoothState.DeviceName:
                    Toast.MakeText(Application.Context, $"Connected to {msg.Data.GetString("DeviceName")}.", ToastLength.Short).Show();
                    break;
            }
        }
    }
}