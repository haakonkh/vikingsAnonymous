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
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using YWWACP.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.BindingContext;

//Author: Student 9787283, Student Kristoffer Helgesen 
namespace YWWACP
{

    //Sets the connection to the mView.
    [MvxViewFor(typeof(GraphViewModel))]
    [Activity(Label = "ChartMainPageActivity")]


    public class ChartMainPageActivity : MvxActivity
    {

   

       protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChartMainPage);
            

            //Ting fra stack -- provd 
            
            //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            //{

            //    //IDF-KNOW
            //    var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            //    var view = this.BindingInflate(Resource.Layout.ChartMainPage, null);

            //    var graphControl = view.FindViewById<PlotView>(Resource.Id.plot_view);

            //    var bindset = this.CreateBindingSet<ChartMainPageActivity, GraphViewModel>();

            //    bindset.Bind(graphControl).For(c => c.Model).To(vm => vm.MyModel);
            //    bindset.Apply();


            //    return view;
            }
            

            //   protected override void OnResume()
            //    {
            //        var vm = (GraphViewModel)ViewModel;
            //         vm.OnResume();
            //         base.OnResume();
            //      }


        }
    }
