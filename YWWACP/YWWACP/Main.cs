using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using YWWACP.Views;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace YWWACP
{
    [Activity(Label = "DrawerLayout", MainLauncher = true, Icon ="@drawable/icon", Theme="@style/MyTheme")]
    public class Main : ActionBarActivity
    {

        private SupportToolbar mToolbar;
        private ActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;

        private ArrayAdapter mLeftAdapter;
        List<string> mLeftItems = new List<string>();
        private ListView mLeftDrawer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

            mLeftItems.Add("First Item");
            mLeftItems.Add("Second Item");

            mLeftAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, mLeftItems);
            mLeftDrawer.Adapter = mLeftAdapter;

            mLeftDrawer.ItemClick += MLeftDrawer_ItemClick;
            SetSupportActionBar(mToolbar);

            mDrawerToggle = new ActionBarDrawerToggle(
                this,                   // Host activity 
                mDrawerLayout,          // Drawer Layout
                Resource.String.openDrawer,  // Open message
                Resource.String.closeDrawer);  // Close message

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mDrawerToggle.SyncState();

        }

        private void MLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int position = e.Position;
            string selectedFromList = mLeftDrawer.GetItemAtPosition(e.Position).ToString();
            if (position == 0)
            {
                var intent = new Intent(this, typeof(CommunityActivity));
                StartActivity(intent);
            }
            else if (position == 1)
            {
                var intent = new Intent(this, typeof(ProfileActivity));
                StartActivity(intent);
            }



        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}