package md517f33fdec71288376de88a7e967f4dc2;


public class RoundedButtonRendererAndroid
	extends md51558244f76c53b6aeda52c8a337f2c37.ButtonRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RecipeFinder.Droid.RoundedButtonRendererAndroid, RecipeFinder.Android", RoundedButtonRendererAndroid.class, __md_methods);
	}


	public RoundedButtonRendererAndroid (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == RoundedButtonRendererAndroid.class)
			mono.android.TypeManager.Activate ("RecipeFinder.Droid.RoundedButtonRendererAndroid, RecipeFinder.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public RoundedButtonRendererAndroid (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == RoundedButtonRendererAndroid.class)
			mono.android.TypeManager.Activate ("RecipeFinder.Droid.RoundedButtonRendererAndroid, RecipeFinder.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public RoundedButtonRendererAndroid (android.content.Context p0)
	{
		super (p0);
		if (getClass () == RoundedButtonRendererAndroid.class)
			mono.android.TypeManager.Activate ("RecipeFinder.Droid.RoundedButtonRendererAndroid, RecipeFinder.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
