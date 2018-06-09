using Android.Content;
using Android.Support.Wear.Widget;
using Android.Views;
using Android.Widget;
using KekaWear.Models;
using System.Collections.Generic;

namespace KekaWear
{
    public class EmpDirRecyclerViewAdapter : WearableRecyclerView.Adapter
    {
        Context context;
        public List<Employee> employees;

        public EmpDirRecyclerViewAdapter(Context context)
        {
            this.context = context;
        }

        public override void OnBindViewHolder(Android.Support.V7.Widget.RecyclerView.ViewHolder viewHolder, int position)
        {
            viewHolder.ItemView.FindViewById<TextView>(Resource.Id.profileImageTextView).Text = employees[position].TwoLetterName;
            viewHolder.ItemView.FindViewById<TextView>(Resource.Id.empNameTxtView).Text = employees[position].FirstName;
        }

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new EmpDirViewHolder(LayoutInflater.FromContext(context).Inflate(Resource.Layout.empDir_item_layout, null));
        }

        public override int ItemCount
        {
            get { return employees.Count; }
        }

        public class EmpDirViewHolder : WearableRecyclerView.ViewHolder
        {
            private TextView profileImgTxtView;
            private TextView empNameTxtView;

            public EmpDirViewHolder(View view) : base(view)
            {
                profileImgTxtView = view.FindViewById<TextView>(Resource.Id.profileImageTextView);
                empNameTxtView = view.FindViewById<TextView>(Resource.Id.empNameTxtView);
            }
        }
    }
}