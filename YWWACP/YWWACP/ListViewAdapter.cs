using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//Author: Student 9805061, Student Andreas Norstein

namespace YWWACP
{
    class ListViewAdapter : BaseAdapter<NewDiscussionThread>
    {
        private List<NewDiscussionThread> mItems;
        private Context mContext;

        public ListViewAdapter(Context context, List<NewDiscussionThread> items)
        {
            mItems = items;
            mContext = context;
        }
        public override int Count
        {
            get { return mItems.Count;  }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override NewDiscussionThread this[int position]
        {
            get
            { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.ListView_Row, null, false);
            }

            TextView txtTitle = row.FindViewById<TextView>(Resource.Id.txtViewTitle);
            txtTitle.Text = mItems[position].Title;

            TextView txtCategory = row.FindViewById<TextView>(Resource.Id.txtViewCategory);
            txtCategory.Text = mItems[position].Category;

            TextView txtContent = row.FindViewById<TextView>(Resource.Id.txtViewContent);
            txtContent.Text = mItems[position].Content;

            return row;
        }
    }

}