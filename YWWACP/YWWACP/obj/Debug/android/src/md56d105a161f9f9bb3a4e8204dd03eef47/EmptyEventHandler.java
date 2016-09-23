package md56d105a161f9f9bb3a4e8204dd03eef47;


public class EmptyEventHandler
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.grapecity.xuni.core.IEventHandler
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_call:(Ljava/lang/Object;Ljava/lang/Object;)V:GetCall_Ljava_lang_Object_Ljava_lang_Object_Handler:Com.GrapeCity.Xuni.Core.IEventHandlerInvoker, Xuni.Android.Core\n" +
			"";
		mono.android.Runtime.register ("Xuni.Android.Core.EmptyEventHandler, Xuni.Android.Core, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", EmptyEventHandler.class, __md_methods);
	}


	public EmptyEventHandler () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EmptyEventHandler.class)
			mono.android.TypeManager.Activate ("Xuni.Android.Core.EmptyEventHandler, Xuni.Android.Core, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void call (java.lang.Object p0, java.lang.Object p1)
	{
		n_call (p0, p1);
	}

	private native void n_call (java.lang.Object p0, java.lang.Object p1);

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
