using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace YWWACP
{
	public class GridAdapter : BaseAdapter
	{
		private readonly Context context;

		public GridAdapter(Context c)
		{
			context = c;
		}

		public override int Count
		{
			get { return recipesIds.Length; }
		}

		public override Object GetItem(int position)
		{
			return recipesIds[position];
		}

		public override long GetItemId(int position)
		{
			return 0;
		}



		// create a new view for each item added to GridAdapter
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			ImageView recipeView;

			// if object is null, initialized with desired properties
			if (convertView == null)
			{
				recipeView = new ImageView(context);
				recipeView.LayoutParameters = new AbsListView.LayoutParams(200, 200); // height and weight for view
				recipeView.SetScaleType(ImageView.ScaleType.CenterCrop); // croppes images to center
				recipeView.SetPadding(5, 5, 5, 5); // declares padding
			}
			// if object is not empty, local recipeView is initialized 
			else
			{
				recipeView = (ImageView)convertView;
			}
			recipeView.SetImageResource(recipesIds[position]); // set image resource 
			return recipeView;
		}

		// references to our images. -> change to own class 
		private readonly int[] recipesIds = {
			
					Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
			        Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
			        Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
					Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
			        Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
					Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
			        Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
					Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
			        Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon,
					Resource.Drawable.recipeIcon, Resource.Drawable.recipeIcon
		};
	}
}