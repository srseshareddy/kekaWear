using Android.App;
using Android.OS;
using Android.Support.Wear.Widget;
using Android.Widget;
using KekaWear.Models;
using KekaWear.Models.Xhr.Core;
using Newtonsoft.Json;
using System.Text;

namespace KekaWear
{
    [Activity(Label = "LeavesActivity")]
    public class LeavesActivity : Activity
    {
        WearableRecyclerView empDirListView;
        LeavesRecyclerViewAdapter leavesRecyclerViewAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            empDirListView = FindViewById<WearableRecyclerView>(Resource.Id.empDirListView);
            leavesRecyclerViewAdapter = new LeavesRecyclerViewAdapter(this);
            SetLeaves();
            empDirListView.SetAdapter(leavesRecyclerViewAdapter);
        }

        private void SetLeaves()
        {
            if (BluetoothManager.bluetoothService.GetState() != ConnectionState.Connected)
            {
                Toast.MakeText(Application.Context, "Not Connected", ToastLength.Long).Show();
                FinishAndRemoveTask();
            }
            BluetoothManager.bluetoothService.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new CommandObjectClass((int)CommandEnum.EmpDirFetch))));
            while (BluetoothManager.result == null)
            {

            }
            var result = JsonConvert.DeserializeObject<ResultObject>(BluetoothManager.result);
            if (result.State == (int)ResultState.Success)
            {
                leavesRecyclerViewAdapter.leavesSummary = result.Result;
            }
            else
            {
                Toast.MakeText(ApplicationContext, "State : " + (ResultState)result.State + " Message : " +
                    result.Result, ToastLength.Long).Show();
            }
            BluetoothManager.result = null;
        }
    }
}