package md53d0a907759989744df270529c70798a1;


public class FirstView
	extends md5c293e307133ee8f46151deed2480c6a8.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("YWWACP.Views.FirstView, YWWACP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FirstView.class, __md_methods);
	}


	public FirstView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FirstView.class)
			mono.android.TypeManager.Activate ("YWWACP.Views.FirstView, YWWACP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
