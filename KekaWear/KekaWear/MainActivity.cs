
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Wearable.Activity;
using Android.Widget;

namespace KekaWear
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity
    {
        Button empDirActivityBtn,leaveActivityBtn,clockInActivityBtn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);

            empDirActivityBtn = FindViewById<Button>(Resource.Id.empDirActivityBtn);
            leaveActivityBtn = FindViewById<Button>(Resource.Id.leavesActivityBtn);
            clockInActivityBtn = FindViewById<Button>(Resource.Id.clockInActivityBtn);

            Intent activityIntent;

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
    }
}


