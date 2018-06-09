using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using KekaWear.Models;
using KekaWear.Models.Xhr.Core;
using Newtonsoft.Json;
using System.Text;

namespace KekaWear
{
    [Activity(Label = "ClockInActivity")]
    public class ClockInActivity : Activity
    {
        Button clockInBtn, punchBtn;
        bool clockInState;
        ResultState clockInFetchStatus;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            clockInBtn = FindViewById<Button>(Resource.Id.clockInBtn);
            punchBtn = FindViewById<Button>(Resource.Id.punchBtn);
            
            clockInState = ClockInStateFetch();
            if(clockInFetchStatus == ResultState.Success)
            {
                ChangeUI();
            }
            else
            {
                FinishAndRemoveTask();
            }

            clockInBtn.Click += (sender, e) =>
            {
                ClockInCall(!clockInState);
                clockInState = ClockInStateFetch();
                if (clockInFetchStatus == ResultState.Success)
                {
                    ChangeUI();
                }
                else
                {
                    clockInBtn.SetTextColor(Color.Red);
                }
            };

            punchBtn.Click += (sender, e) =>
            {
                Punch();
            };
        }

        private void ChangeUI()
        {
            if (!clockInState)
            {
                clockInBtn.SetBackgroundColor(Color.Green);
                clockInBtn.Text = "Clock In";
            }
            else
            {
                clockInBtn.SetBackgroundColor(Color.LightGray);
                clockInBtn.Text = "Clock Out";
            }
        }

        private bool ClockInStateFetch()
        {
            while (BluetoothManager.result == null)
            {

            }
            var result = JsonConvert.DeserializeObject<ResultObject>(BluetoothManager.result);
            clockInFetchStatus = (ResultState)result.State;
            if (result.State == (int)ResultState.Success)
            {
                return (bool)result.Result;
            }
            else
            {
                Toast.MakeText(ApplicationContext, "State : " + (ResultState)result.State + " Message : " + result.Result, ToastLength.Long).Show();
                return false;
            }
        }

        private void ClockInCall(bool clockInNewState)
        {
            if (BluetoothManager.bluetoothService.GetState() != ConnectionState.Connected)
            {
                Toast.MakeText(Application.Context, "Not Connected", ToastLength.Long).Show();
                FinishAndRemoveTask();
            }
            BluetoothManager.bluetoothService.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new CommandObjectClass((int)
                ( (clockInNewState)? CommandEnum.ClockIn : CommandEnum.ClockOut)
                ))));
        }

        private void Punch()
        {
            if (BluetoothManager.bluetoothService.GetState() != ConnectionState.Connected)
            {
                Toast.MakeText(Application.Context, "Not Connected", ToastLength.Long).Show();
                FinishAndRemoveTask();
            }
            BluetoothManager.bluetoothService.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new CommandObjectClass((int)CommandEnum.Punch))));
            var result = JsonConvert.DeserializeObject<ResultObject>(BluetoothManager.result);
            if (result.State == (int)ResultState.Success)
            {
                clockInBtn.SetBackgroundColor(Color.Green);
            }
            else
            {
                clockInBtn.SetBackgroundColor(Color.Red);
                Toast.MakeText(ApplicationContext, "State : " + (ResultState)result.State + " Message : " +
                    result.Result, ToastLength.Long).Show();
            }
        }
    }
}