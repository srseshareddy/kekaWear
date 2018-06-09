using Android.Content;
using Android.Support.Wear.Widget;
using Android.Views;
using Android.Widget;
using KekaWear.Models;
using System.Collections.Generic;

namespace KekaWear
{
    public class LeavesRecyclerViewAdapter : WearableRecyclerView.Adapter
    {
        Context context;
        public List<LeaveTypeSummary> leavesSummary;

        public LeavesRecyclerViewAdapter(Context context)
        {
            this.context = context;
        }

        public override void OnBindViewHolder(Android.Support.V7.Widget.RecyclerView.ViewHolder viewHolder, int position)
        {
            viewHolder.ItemView.FindViewById<TextView>(Resource.Id.leaveTypeTxtView).Text = leavesSummary[position].Name;
            viewHolder.ItemView.FindViewById<TextView>(Resource.Id.leavesAvailiableTxtView).Text = leavesSummary[position].AvailableInDays.ToString();
        }

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new LeavesViewHolder(LayoutInflater.FromContext(context).Inflate(Resource.Layout.leaves_item_layout, null));
        }

        public override int ItemCount
        {
            get { return leavesSummary.Count; }
        }

        public class LeavesViewHolder : WearableRecyclerView.ViewHolder
        {
            private TextView leaveTypeTxtView;
            private TextView leavesAvailiableTxtView;

            public LeavesViewHolder(View view) : base(view)
            {
                leaveTypeTxtView = view.FindViewById<TextView>(Resource.Id.leaveTypeTxtView);
                leavesAvailiableTxtView = view.FindViewById<TextView>(Resource.Id.leavesAvailiableTxtView);
            }
        }
    }
}