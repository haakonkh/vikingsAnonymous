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

namespace YWWACP
{
    public class OnSubmitArgs : EventArgs
    {
        private string mTitle;
        //private Spinner mDropdown; // categories, cannot make this work
        private string mCategory;
        private string mContent;

        public string Title
        {
            get { return mTitle; }
            set { mTitle = value;  }    
        }

        public string Category
        {
            get { return mCategory; }
            set { mCategory = value;  }

        }

        public string Content
        {
            get { return mContent; }
            set { mContent = value; }
        }

        public OnSubmitArgs(string title, string category, string content) : base()
        {
            Title = title;
            Category = category;
            Content = content;
        }
        
    }

    [Activity(Label = "dialog_new_thread")]
    class dialog_new_thread : DialogFragment
    {
        private Spinner dropdown;
        private Button mSubmit;
        private EditText mTitle;
        private EditText mContent;

        public event EventHandler<OnSubmitArgs> mOnSubmit;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Dialog_New_Thread, container, false);

            // Cancels the new thread
            view.FindViewById<Button>(Resource.Id.btnCancelThread).Click += (sender, args) => Dismiss();

            // Submit button 
            mSubmit = view.FindViewById<Button>(Resource.Id.btnSubmitThread);
            mSubmit.Click += MSubmit_Click;

            // Text typed in by users, Title and Content
            // Edit text fields
            mTitle = view.FindViewById<EditText>(Resource.Id.editTxtTitle);
            mContent = view.FindViewById<EditText>(Resource.Id.editTxtQuestion);
            
            // Categories dropdown connected with view
            dropdown = view.FindViewById<Spinner>(Resource.Id.spinnerCategories);
            
            // prompts the user which category that are selected... 
            //dropdown.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            // Create spinner-dropdown
            var adapter = ArrayAdapter.CreateFromResource(Activity, Resource.Array.categories_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            dropdown.Adapter = adapter;
       
            return view;

        }
        
        // If something is to be submitted
        private void MSubmit_Click(object sender, EventArgs e)
        {
            mOnSubmit.Invoke(this, new OnSubmitArgs(mTitle.Text, dropdown.SelectedItem.ToString(), mContent.Text));
            this.Dismiss();
        }

        // Prompts the user which category that's seleceted
        // I do not think this is necessary
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("The category is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(Activity, toast, ToastLength.Long).Show();

        }

        
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.SwipeToDismiss);
            base.OnActivityCreated(savedInstanceState);
                   
        }

    }
}