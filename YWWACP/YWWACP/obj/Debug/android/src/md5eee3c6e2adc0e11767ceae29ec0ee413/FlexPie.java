package md5eee3c6e2adc0e11767ceae29ec0ee413;


public class FlexPie
	extends com.grapecity.xuni.flexpie.FlexPie
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemsSource:()Ljava/util/List;:GetGetItemsSourceHandler\n" +
			"n_setItemsSource:(Ljava/util/List;)V:GetSetItemsSource_Ljava_util_List_Handler\n" +
			"n_onSelectionChanged:(Lcom/grapecity/xuni/flexpie/FlexPieHitTestInfo;)V:GetOnSelectionChanged_Lcom_grapecity_xuni_flexpie_FlexPieHitTestInfo_Handler\n" +
			"n_onRendering:()V:GetOnRenderingHandler\n" +
			"n_onRendered:()V:GetOnRenderedHandler\n" +
			"n_onTapped:(Landroid/graphics/Point;)V:GetOnTapped_Landroid_graphics_Point_Handler\n" +
			"";
		mono.android.Runtime.register ("Com.GrapeCity.Xuni.FlexPie.FlexPie, Xuni.Android.FlexPie, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", FlexPie.class, __md_methods);
	}


	public FlexPie (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == FlexPie.class)
			mono.android.TypeManager.Activate ("Com.GrapeCity.Xuni.FlexPie.FlexPie, Xuni.Android.FlexPie, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public FlexPie (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == FlexPie.class)
			mono.android.TypeManager.Activate ("Com.GrapeCity.Xuni.FlexPie.FlexPie, Xuni.Android.FlexPie, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public FlexPie (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == FlexPie.class)
			mono.android.TypeManager.Activate ("Com.GrapeCity.Xuni.FlexPie.FlexPie, Xuni.Android.FlexPie, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public java.util.List getItemsSource ()
	{
		return n_getItemsSource ();
	}

	private native java.util.List n_getItemsSource ();


	public void setItemsSource (java.util.List p0)
	{
		n_setItemsSource (p0);
	}

	private native void n_setItemsSource (java.util.List p0);


	public void onSelectionChanged (com.grapecity.xuni.flexpie.FlexPieHitTestInfo p0)
	{
		n_onSelectionChanged (p0);
	}

	private native void n_onSelectionChanged (com.grapecity.xuni.flexpie.FlexPieHitTestInfo p0);


	public void onRendering ()
	{
		n_onRendering ();
	}

	private native void n_onRendering ();


	public void onRendered ()
	{
		n_onRendered ();
	}

	private native void n_onRendered ();


	public void onTapped (android.graphics.Point p0)
	{
		n_onTapped (p0);
	}

	private native void n_onTapped (android.graphics.Point p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
