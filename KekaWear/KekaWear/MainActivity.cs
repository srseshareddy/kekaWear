using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Support.Wearable.Activity;
using Android.Widget;
using KekaWear.Models.Xhr.Core;
using System;

namespace KekaWear
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity
    {
        Button empDirActivityBtn,leaveActivityBtn,clockInActivityBtn;
        public string pairedBluetoothDeviceName;
        public string pairedBluetoothDeviceAddress;
        const int REQUEST_ENABLE_BT = 1;
        public bool DeviceConnected;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);

            BluetoothManager.bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            BluetoothManager.result = null;

            empDirActivityBtn = FindViewById<Button>(Resource.Id.empDirActivityBtn);
            leaveActivityBtn = FindViewById<Button>(Resource.Id.leavesActivityBtn);
            clockInActivityBtn = FindViewById<Button>(Resource.Id.clockInActivityBtn);

            Intent activityIntent;

            empDirActivityBtn.Clickable = false;
            leaveActivityBtn.Clickable = false;
            clockInActivityBtn.Clickable = false;

            empDirActivityBtn.Click += (sender, e) =>
            {
                activityIntent = new Intent(this, typeof(EmployeeDirActivity));
                StartActivity(activityIntent);
            };

            leaveActivityBtn.Click += (sender, e) =>
            {
                activityIntent = new Intent(this, typeof(LeavesActivity));
                StartActivity(activityIntent);
            };

            clockInActivityBtn.Click += (sender, e) =>
            {
                activityIntent = new Intent(this, typeof(ClockInActivity));
                StartActivity(activityIntent);
            };

            SetAmbientEnabled();
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (BluetoothAdapter.DefaultAdapter == null)
            {
                Toast.MakeText(ApplicationContext, "Bluetooth Not Supported", ToastLength.Short).Show();
                this.FinishAndRemoveTask();
            }
            else if (!BluetoothAdapter.DefaultAdapter.IsEnabled)
            {
                var enableIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
                StartActivityForResult(enableIntent, REQUEST_ENABLE_BT);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            switch (requestCode)
            {
                case REQUEST_ENABLE_BT:
                    if (Result.Ok != resultCode)
                    {
                        Toast.MakeText(ApplicationContext, "Bluetooth Not Enabled", ToastLength.Short).Show();
                        this.FinishAndRemoveTask();
                    }
                    else
                    {
                        BluetoothManager.bluetoothHandler = new BluetoothHandler(this);
                        CheckAvailiableDevices();
                    }
                    break;
            }
        }

        private void CheckAvailiableDevices()
        {
            var listOfDevices = BluetoothAdapter.DefaultAdapter.BondedDevices;
            if (listOfDevices.Count > 0)
            {
                try
                {
                    foreach (BluetoothDevice bluetoothDevice in listOfDevices)
                    {
                        if (bluetoothDevice.BondState == Bond.Bonded && bluetoothDevice.BluetoothClass.MajorDeviceClass == MajorDeviceClass.Phone)
                        {
                            pairedBluetoothDeviceName = bluetoothDevice.Name;
                            pairedBluetoothDeviceAddress = bluetoothDevice.Address;
                        }
                    }
                    if (pairedBluetoothDeviceAddress != null)
                    {
                        BluetoothManager.bluetoothService = new BluetoothService(BluetoothManager.bluetoothHandler);
                        ConnectDevice();
                    }
                    else
                    {
                        Toast.MakeText(Application.Context, "No Active Connections Availiable", ToastLength.Long).Show();
                    }
                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "Connections Not availiable" + e.Message, ToastLength.Long).Show();
                    this.FinishAndRemoveTask();
                }
            }
            else
            {
                Toast.MakeText(ApplicationContext, "Bluetooth Connections Not Availiable", ToastLength.Short).Show();
                this.FinishAndRemoveTask();
            }
        }

        private void ConnectDevice()
        {
            while(BluetoothManager.bluetoothService.GetState() != ConnectionState.Connected)
            {
                try
                {
                    BluetoothManager.bluetoothService.Connect(BluetoothManager.bluetoothAdapter.GetRemoteDevice(pairedBluetoothDeviceAddress));
                    break;
                }
                catch (Exception e)
                {
                    
                }
            }
            empDirActivityBtn.Clickable = true;
            leaveActivityBtn.Clickable = true;
            clockInActivityBtn.Clickable = true;
        }

    }
}