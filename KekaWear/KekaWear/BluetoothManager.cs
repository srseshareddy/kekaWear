using Android.Bluetooth;
using KekaWear.Models.Xhr.Core;

namespace KekaWear
{
    public static class BluetoothManager
    {
        public static BluetoothHandler bluetoothHandler { get; set; }
        public static BluetoothAdapter bluetoothAdapter { get; set; }
        public static BluetoothService bluetoothService { get; set; }
        public static dynamic result { get; set; }
    }

    public static class AutoMapping
    {
        public static ResultState MapTo(this int resultState)
        {
            return (ResultState)resultState;
        }
    }
}