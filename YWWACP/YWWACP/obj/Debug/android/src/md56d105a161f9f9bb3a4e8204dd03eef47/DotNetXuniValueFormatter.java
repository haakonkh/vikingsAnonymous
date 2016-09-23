package md56d105a161f9f9bb3a4e8204dd03eef47;


public class DotNetXuniValueFormatter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.grapecity.xuni.core.globalization.IXuniValueFormatter
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_format:(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/String;:GetFormat_Ljava_lang_Object_Ljava_lang_String_Handler:Com.GrapeCity.Xuni.Core.Globalization.IXuniValueFormatterInvoker, Xuni.Android.Core\n" +
			"n_format:(Ljava/lang/Object;Ljava/lang/String;Lcom/grapecity/xuni/core/DataType;)Ljava/lang/String;:GetFormat_Ljava_lang_Object_Ljava_lang_String_Lcom_grapecity_xuni_core_DataType_Handler:Com.GrapeCity.Xuni.Core.Globalization.IXuniValueFormatterInvoker, Xuni.Android.Core\n" +
			"";
		mono.android.Runtime.register ("Xuni.Android.Core.DotNetXuniValueFormatter, Xuni.Android.Core, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", DotNetXuniValueFormatter.class, __md_methods);
	}


	public DotNetXuniValueFormatter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DotNetXuniValueFormatter.class)
			mono.android.TypeManager.Activate ("Xuni.Android.Core.DotNetXuniValueFormatter, Xuni.Android.Core, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String format (java.lang.Object p0, java.lang.String p1)
	{
		return n_format (p0, p1);
	}

	private native java.lang.String n_format (java.lang.Object p0, java.lang.String p1);


	public java.lang.String format (java.lang.Object p0, java.lang.String p1, com.grapecity.xuni.core.DataType p2)
	{
		return n_format (p0, p1, p2);
	}

	private native java.lang.String n_format (java.lang.Object p0, java.lang.String p1, com.grapecity.xuni.core.DataType p2);

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
