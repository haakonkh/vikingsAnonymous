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
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;


namespace YWWACP
{

    public class GridAdapter_exercise : BaseAdapter
    {
        private readonly Context context;

        public GridAdapter_exercise(Context c)
        {
            context = c;
        }

        public override int Count
        {
            get { return exerciseIds.Length; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return exerciseIds[position];
        }

        public override long GetItemId(int position)
        {
            return 0;
        }



        // create a new view for each item added to GridAdapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView exerciseView;



            // if object is null, initialized with desired properties
            if (convertView == null)
            {
                exerciseView = new ImageView(context);
                exerciseView.LayoutParameters = new AbsListView.LayoutParams(200, 200); // height and weight for view
                exerciseView.SetScaleType(ImageView.ScaleType.CenterCrop); // croppes images to center
                exerciseView.SetPadding(5, 5, 5, 5); // declares padding               
            }
            // if object is not empty, local recipeView is initialized 
            else
            {
                exerciseView = (ImageView)convertView;
            }
            exerciseView.SetImageResource(exerciseIds[position]); // set image resource 
            return exerciseView;
        }




        // references to our images. -> change to own class 
        private readonly int[] exerciseIds = {


                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell,
                    Resource.Drawable.barbell, Resource.Drawable.barbell
        };
        private readonly int[] exerciseButton = {


                    Resource.Drawable.recipe, Resource.Drawable.barbell

        };
    }
}