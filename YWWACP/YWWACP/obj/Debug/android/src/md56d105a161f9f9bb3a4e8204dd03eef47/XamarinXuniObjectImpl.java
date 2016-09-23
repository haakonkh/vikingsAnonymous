package md56d105a161f9f9bb3a4e8204dd03eef47;


public class XamarinXuniObjectImpl
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.grapecity.xuni.core.XamarinXuniObject
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getPropertyNames:()Ljava/util/List;:GetGetPropertyNamesHandler:Com.GrapeCity.Xuni.Core.IXamarinXuniObjectInvoker, Xuni.Android.Core\n" +
			"n_getPropertyValue:(Ljava/lang/String;)Ljava/lang/Object;:GetGetPropertyValue_Ljava_lang_String_Handler:Com.GrapeCity.Xuni.Core.IXamarinXuniObjectInvoker, Xuni.Android.Core\n" +
			"n_setPropertyValue:(Ljava/lang/String;Ljava/lang/Object;)V:GetSetPropertyValue_Ljava_lang_String_Ljava_lang_Object_Handler:Com.GrapeCity.Xuni.Core.IXamarinXuniObjectInvoker, Xuni.Android.Core\n" +
			"";
		mono.android.Runtime.register ("Xuni.Android.Core.XamarinXuniObjectImpl, Xuni.Android.Core, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", XamarinXuniObjectImpl.class, __md_methods);
	}


	public XamarinXuniObjectImpl () throws java.lang.Throwable
	{
		super ();
		if (getClass () == XamarinXuniObjectImpl.class)
			mono.android.TypeManager.Activate ("Xuni.Android.Core.XamarinXuniObjectImpl, Xuni.Android.Core, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.util.List getPropertyNames ()
	{
		return n_getPropertyNames ();
	}

	private native java.util.List n_getPropertyNames ();


	public java.lang.Object getPropertyValue (java.lang.String p0)
	{
		return n_getPropertyValue (p0);
	}

	private native java.lang.Object n_getPropertyValue (java.lang.String p0);


	public void setPropertyValue (java.lang.String p0, java.lang.Object p1)
	{
		n_setPropertyValue (p0, p1);
	}

	private native void n_setPropertyValue (java.lang.String p0, java.lang.Object p1);

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
