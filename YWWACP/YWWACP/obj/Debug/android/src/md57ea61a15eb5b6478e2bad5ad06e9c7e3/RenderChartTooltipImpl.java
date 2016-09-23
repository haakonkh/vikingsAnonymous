package md57ea61a15eb5b6478e2bad5ad06e9c7e3;


public class RenderChartTooltipImpl
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.grapecity.xuni.chartcore.IXamarinOverrideTooltip,
		com.grapecity.xuni.chartcore.IXuniTooltipRendering
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_hide:(Landroid/view/View;)V:GetHide_Landroid_view_View_Handler:Com.GrapeCity.Xuni.ChartCore.IXamarinOverrideTooltipInvoker, Xuni.Android.ChartCore\n" +
			"n_setContainerDimensions:(Landroid/view/View;FFFF)V:GetSetContainerDimensions_Landroid_view_View_FFFFHandler:Com.GrapeCity.Xuni.ChartCore.IXamarinOverrideTooltipInvoker, Xuni.Android.ChartCore\n" +
			"n_show:(Landroid/view/View;)V:GetShow_Landroid_view_View_Handler:Com.GrapeCity.Xuni.ChartCore.IXamarinOverrideTooltipInvoker, Xuni.Android.ChartCore\n" +
			"n_renderTooltip:([Ljava/lang/Object;)V:GetRenderTooltip_arrayLjava_lang_Object_Handler:Com.GrapeCity.Xuni.ChartCore.IXuniTooltipRenderingInvoker, Xuni.Android.ChartCore\n" +
			"";
		mono.android.Runtime.register ("Xuni.Forms.FlexPie.Platform.Android.Interfaces.RenderChartTooltipImpl, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", RenderChartTooltipImpl.class, __md_methods);
	}


	public RenderChartTooltipImpl () throws java.lang.Throwable
	{
		super ();
		if (getClass () == RenderChartTooltipImpl.class)
			mono.android.TypeManager.Activate ("Xuni.Forms.FlexPie.Platform.Android.Interfaces.RenderChartTooltipImpl, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void hide (android.view.View p0)
	{
		n_hide (p0);
	}

	private native void n_hide (android.view.View p0);


	public void setContainerDimensions (android.view.View p0, float p1, float p2, float p3, float p4)
	{
		n_setContainerDimensions (p0, p1, p2, p3, p4);
	}

	private native void n_setContainerDimensions (android.view.View p0, float p1, float p2, float p3, float p4);


	public void show (android.view.View p0)
	{
		n_show (p0);
	}

	private native void n_show (android.view.View p0);


	public void renderTooltip (java.lang.Object[] p0)
	{
		n_renderTooltip (p0);
	}

	private native void n_renderTooltip (java.lang.Object[] p0);

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
