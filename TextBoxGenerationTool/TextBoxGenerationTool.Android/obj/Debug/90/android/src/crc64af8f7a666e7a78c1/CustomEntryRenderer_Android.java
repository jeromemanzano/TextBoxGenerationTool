package crc64af8f7a666e7a78c1;


public class CustomEntryRenderer_Android
	extends crc643f46942d9dd1fff9.EditorRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TextBoxGenerationTool.Droid.CustomRenderers.CustomEntryRenderer_Android, TextBoxGenerationTool.Android", CustomEntryRenderer_Android.class, __md_methods);
	}


	public CustomEntryRenderer_Android (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomEntryRenderer_Android.class)
			mono.android.TypeManager.Activate ("TextBoxGenerationTool.Droid.CustomRenderers.CustomEntryRenderer_Android, TextBoxGenerationTool.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomEntryRenderer_Android (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomEntryRenderer_Android.class)
			mono.android.TypeManager.Activate ("TextBoxGenerationTool.Droid.CustomRenderers.CustomEntryRenderer_Android, TextBoxGenerationTool.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomEntryRenderer_Android (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomEntryRenderer_Android.class)
			mono.android.TypeManager.Activate ("TextBoxGenerationTool.Droid.CustomRenderers.CustomEntryRenderer_Android, TextBoxGenerationTool.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
