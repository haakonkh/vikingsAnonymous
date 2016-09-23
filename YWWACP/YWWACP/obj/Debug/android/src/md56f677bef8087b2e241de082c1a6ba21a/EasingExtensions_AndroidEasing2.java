package md56f677bef8087b2e241de082c1a6ba21a;


public class EasingExtensions_AndroidEasing2
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.animation.TimeInterpolator
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getInterpolation:(F)F:GetGetInterpolation_FHandler:Android.Animation.ITimeInterpolatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xuni.Forms.FlexPie.Platform.Android.Extensions.EasingExtensions+AndroidEasing2, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", EasingExtensions_AndroidEasing2.class, __md_methods);
	}


	public EasingExtensions_AndroidEasing2 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EasingExtensions_AndroidEasing2.class)
			mono.android.TypeManager.Activate ("Xuni.Forms.FlexPie.Platform.Android.Extensions.EasingExtensions+AndroidEasing2, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public float getInterpolation (float p0)
	{
		return n_getInterpolation (p0);
	}

	private native float n_getInterpolation (float p0);

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
