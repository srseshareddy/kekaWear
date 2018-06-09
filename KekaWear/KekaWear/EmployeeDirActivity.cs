using System.Text;
using Android.App;
using Android.OS;
using Android.Support.Wearable.Views;
using Android.Widget;
using KekaWear.Models;
using KekaWear.Models.Xhr.Core;
using Newtonsoft.Json;

namespace KekaWear
{
    [Activity(Label = "EmployeeDirActivity")]
    public class EmployeeDirActivity : Activity
    {
        WearableRecyclerView empDirListView;
        EmpDirRecyclerViewAdapter empDirRecyclerViewAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_employeeDir);
            empDirListView = FindViewById<WearableRecyclerView>(Resource.Id.empDirListView);
            empDirRecyclerViewAdapter = new EmpDirRecyclerViewAdapter(this);
            SetEmployees();
            empDirListView.SetAdapter(empDirRecyclerViewAdapter);
        }

        private void SetEmployees()
        {
            if (BluetoothManager.bluetoothService.GetState() != ConnectionState.Connected)
            {
                Toast.MakeText(Application.Context, "Not Connected", ToastLength.Long).Show();
                FinishAndRemoveTask();
            }
            BluetoothManager.bluetoothService.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new CommandObjectClass((int)CommandEnum.EmpDirFetch))));
            while(BluetoothManager.result == null)
            {

            }
            var result = JsonConvert.DeserializeObject<ResultObject>(BluetoothManager.result);
            if(result.State == (int)ResultState.Success)
            {
                empDirRecyclerViewAdapter.employees = result.Result;
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