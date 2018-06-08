using Android.App;
using Android.OS;
using Android.Widget;
using System.Text;

namespace Keka_Sample
{
    public partial class MainActivity
    {
        public class BluetoothHandler : Handler
        {
            MainActivity mainActivity;
            public BluetoothHandler(MainActivity frag)
            {
                mainActivity = frag;

            }
            public override void HandleMessage(Message msg)
            {
                switch (msg.What)
                {
                    case (int)BluetoothState.Change:
                        Toast.MakeText(Application.Context, "Connection State : " + (ConnectionState)msg.Arg1, ToastLength.Long).Show();
                        break;
                    case (int)BluetoothState.Write:
                        var writeBuffer = (byte[])msg.Obj;
                        var writeMessage = Encoding.ASCII.GetString(writeBuffer);
                        Toast.MakeText(Application.Context, "Connection State : " + (BluetoothState)msg.What, ToastLength.Long).Show();
                        Toast.MakeText(Application.Context, writeMessage, ToastLength.Long).Show();
                        break;
                    case (int)BluetoothState.Read:
                        Toast.MakeText(Application.Context, "Connection State : " + (BluetoothState)msg.What, ToastLength.Long).Show();
                        var readBuffer = (byte[])msg.Obj;
                        mainActivity.receivedMsgTxtView.Text = Encoding.ASCII.GetString(readBuffer);
                        break;
                    case (int)BluetoothState.DeviceName:
                        Toast.MakeText(Application.Context, "Connection State : " + (BluetoothState)msg.What, ToastLength.Long).Show();
                        Toast.MakeText(Application.Context, $"Connected to {msg.Data.GetString("DeviceName")}.", ToastLength.Short).Show();
                        break;
                }
            }
        }
    }
}