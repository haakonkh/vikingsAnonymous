//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;

//namespace YWWACP
//{
//    //Author: Student 9792538, Student Eirik Baug
//    class dialog_ChooseHealthPlan : DialogFragment
//    {
//        private Button addNew;
//        private Button addExisting;

//        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
//        {
//             base.OnCreateView(inflater, container, savedInstanceState);

//            var view = inflater.Inflate(Resource.Layout.Dialog_ChooseHealthPlan, container, false);

//            addNew = view.FindViewById<Button>(Resource.Id.btnNew);
//            addExisting = view.FindViewById<Button>(Resource.Id.btnExisting);

//            addNew.Click += AddNew_Click;

//            return view;
//        }

//        private void AddNew_Click(object sender, EventArgs e)
//        {
//            //Add new health plan
//            var intent = new Intent(Context, typeof(NewHealthPlanActivity));
//            StartActivity(intent);
//        }

//        public override void OnActivityCreated(Bundle savedInstanceState)
//        {
//            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Make title bar invisible
//            base.OnActivityCreated(savedInstanceState);
//            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //Add animation to dialog
//        }
//    }
//}