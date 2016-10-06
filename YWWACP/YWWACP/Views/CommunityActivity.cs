using Android.App;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;

//Author: Student 9805061, Student Andreas Norstein
namespace YWWACP.Views
{
    [MvxFragment(typeof(ParentViewModel), Resource.Id.frameLayout)]
    [Register("YWWACP.Community")]
    public class CommunityActivity : MvxFragment
    {
        //private Button mNewThread;
        //    private Button mMyThreads;
        //private ListView mListView;
        //private ListViewAdapter mAdapter;

        //private List<NewDiscussionThread> mItems;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Community);

            // Connecting buttons to view
            //mNewThread = FindViewById<Button>(Resource.Id.btnNewThread);
            //mMyThreads = FindViewById<Button>(Resource.Id.btnMyThreads);



            //mListView = FindViewById<ListView>(Resource.Id.listViewCommunity);
            //mItems = new List<NewDiscussionThread>();

            ////mNewThread.Click += MNewThread_Click;

            //mAdapter = new ListViewAdapter(this, mItems);
            //mListView.Adapter = mAdapter;
        }

        protected override void OnResume()
        {
            var vm = (CommunityViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }

        // When clicked, new thread will be created and and placed 
        // below the buttons
        //private void MNewThread_Click(object sender, EventArgs e)
        //{
        //    FragmentTransaction transaction = FragmentManager.BeginTransaction();
        //    dialog_new_thread newThreadDialog = new dialog_new_thread(); 
        //    newThreadDialog.Show(transaction, "dialog fragment");

        //    newThreadDialog.mOnSubmit += NewThreadDialog_mOnSubmit;

        //}

        //private void NewThreadDialog_mOnSubmit(object sender, OnSubmitArgs e)
        //{
        //    mItems.Insert(0, new NewDiscussionThread() { Title = e.Title, Category = e.Category, Content = e.Content });
        // }
    }


}