package md5726ce2ad440c133371e6dcf6678e3817;


public class PlatformFlexPie
	extends md5eee3c6e2adc0e11767ceae29ec0ee413.FlexPie
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_refreshRenderEngine:(II)V:GetRefreshRenderEngine_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Xuni.Forms.FlexPie.Platform.Android.PlatformFlexPie, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", PlatformFlexPie.class, __md_methods);
	}


	public PlatformFlexPie (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == PlatformFlexPie.class)
			mono.android.TypeManager.Activate ("Xuni.Forms.FlexPie.Platform.Android.PlatformFlexPie, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public PlatformFlexPie (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == PlatformFlexPie.class)
			mono.android.TypeManager.Activate ("Xuni.Forms.FlexPie.Platform.Android.PlatformFlexPie, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public PlatformFlexPie (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == PlatformFlexPie.class)
			mono.android.TypeManager.Activate ("Xuni.Forms.FlexPie.Platform.Android.PlatformFlexPie, Xuni.Forms.FlexPie.Platform.Android, Version=2.3.20162.126, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void refreshRenderEngine (int p0, int p1)
	{
		n_refreshRenderEngine (p0, p1);
	}

	private native void n_refreshRenderEngine (int p0, int p1);

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
