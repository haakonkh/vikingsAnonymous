package md57ea61a15eb5b6478e2bad5ad06e9c7e3;


public class DataLabelListener
	extends com.grapecity.xuni.flexpie.DefaultRenderDataLabel
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_execute:([Ljava/lang/Object;)Ljava/lang/Object;:GetExecute_arrayLjava_lang_Object_Handler\n" +
			"n_getDataLabelSizeF:(Lcom/grapecity/xuni/flexpie/FlexPie;Lcom/grapecity/xuni/flexpie/FlexPieHitTestInfo;Lcom/grapecity/xuni/chartcore/CanvasRenderEngine;)Lcom/grapecity/xuni/core/SizeF;:GetGetDataLabelSizeF_Lcom_grapecity_xuni_flexpie_FlexPie_Lcom_grapecity_xuni_flexpie_FlexPieHitTestInfo_Lcom_grapecity_xuni_chartcore_CanvasRenderEngine_Handler\n" +
			"n_getMaxDataLabelSizeF:(Lcom/grapecity/xuni/flexpie/FlexPie;Lcom/grapecity/xuni/flexpie/PieDataLabel;Ljava/util/List;Ljava/util/List;Lcom/grapecity/xuni/chartcore/CanvasRenderEngine;)Lcom/grapecity/xuni/core/SizeF;:GetGetMaxDataLabelSizeF_Lcom_grapecity_xuni_flexpie_FlexPie_Lcom_grapecity_xuni_flexpie_PieDataLabel_Ljava_util_List_Ljava_util_List_Lcom_grapecity_xuni_chartcore_CanvasRenderEngine_Handler\n" +
			"";
		mono.android.Runtime.register ("Xuni.Forms.FlexPie.Platform.Android.Interfaces.DataLabelListener, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", DataLabelListener.class, __md_methods);
	}


	public DataLabelListener (com.grapecity.xuni.flexpie.FlexPie p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DataLabelListener.class)
			mono.android.TypeManager.Activate ("Xuni.Forms.FlexPie.Platform.Android.Interfaces.DataLabelListener, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "Com.GrapeCity.Xuni.FlexPie.SuperFlexPie, Xuni.Android.FlexPie, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public java.lang.Object execute (java.lang.Object[] p0)
	{
		return n_execute (p0);
	}

	private native java.lang.Object n_execute (java.lang.Object[] p0);


	public com.grapecity.xuni.core.SizeF getDataLabelSizeF (com.grapecity.xuni.flexpie.FlexPie p0, com.grapecity.xuni.flexpie.FlexPieHitTestInfo p1, com.grapecity.xuni.chartcore.CanvasRenderEngine p2)
	{
		return n_getDataLabelSizeF (p0, p1, p2);
	}

	private native com.grapecity.xuni.core.SizeF n_getDataLabelSizeF (com.grapecity.xuni.flexpie.FlexPie p0, com.grapecity.xuni.flexpie.FlexPieHitTestInfo p1, com.grapecity.xuni.chartcore.CanvasRenderEngine p2);


	public com.grapecity.xuni.core.SizeF getMaxDataLabelSizeF (com.grapecity.xuni.flexpie.FlexPie p0, com.grapecity.xuni.flexpie.PieDataLabel p1, java.util.List p2, java.util.List p3, com.grapecity.xuni.chartcore.CanvasRenderEngine p4)
	{
		return n_getMaxDataLabelSizeF (p0, p1, p2, p3, p4);
	}

	private native com.grapecity.xuni.core.SizeF n_getMaxDataLabelSizeF (com.grapecity.xuni.flexpie.FlexPie p0, com.grapecity.xuni.flexpie.PieDataLabel p1, java.util.List p2, java.util.List p3, com.grapecity.xuni.chartcore.CanvasRenderEngine p4);

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
