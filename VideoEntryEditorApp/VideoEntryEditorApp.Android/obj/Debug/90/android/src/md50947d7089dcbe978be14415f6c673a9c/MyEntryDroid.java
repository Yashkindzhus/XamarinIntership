package md50947d7089dcbe978be14415f6c673a9c;


public class MyEntryDroid
	extends md51558244f76c53b6aeda52c8a337f2c37.EntryRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("VideoEntryEditorApp.Droid.MyEntryDroid, VideoEntryEditorApp.Android", MyEntryDroid.class, __md_methods);
	}


	public MyEntryDroid (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MyEntryDroid.class)
			mono.android.TypeManager.Activate ("VideoEntryEditorApp.Droid.MyEntryDroid, VideoEntryEditorApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MyEntryDroid (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MyEntryDroid.class)
			mono.android.TypeManager.Activate ("VideoEntryEditorApp.Droid.MyEntryDroid, VideoEntryEditorApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MyEntryDroid (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MyEntryDroid.class)
			mono.android.TypeManager.Activate ("VideoEntryEditorApp.Droid.MyEntryDroid, VideoEntryEditorApp.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
