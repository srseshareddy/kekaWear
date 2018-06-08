using Android.App;
using Android.Content;
using Android.Widget;

namespace Keka_Sample
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class BluetoothBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(Application.Context, intent.Action, ToastLength.Short).Show();
        }
    }
}