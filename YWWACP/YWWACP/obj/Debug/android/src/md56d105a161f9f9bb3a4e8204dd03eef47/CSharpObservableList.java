package md56d105a161f9f9bb3a4e8204dd03eef47;


public class CSharpObservableList
	extends com.grapecity.xuni.core.ObservableList
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xuni.Android.Core.CSharpObservableList, Xuni.Android.Core, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", CSharpObservableList.class, __md_methods);
	}


	public CSharpObservableList () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CSharpObservableList.class)
			mono.android.TypeManager.Activate ("Xuni.Android.Core.CSharpObservableList, Xuni.Android.Core, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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