using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sanford.Collections.Immutable;

public class ES2UserType_SanfordCollectionsImmutableArrayList : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		Sanford.Collections.Immutable.ArrayList data = (Sanford.Collections.Immutable.ArrayList)obj;
		// Add your writer.Write calls here.

	}
	
	public override object Read(ES2Reader reader)
	{
		Sanford.Collections.Immutable.ArrayList data = new Sanford.Collections.Immutable.ArrayList();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		Sanford.Collections.Immutable.ArrayList data = (Sanford.Collections.Immutable.ArrayList)c;
		// Add your reader.Read calls here to read the data into the object.

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_SanfordCollectionsImmutableArrayList():base(typeof(Sanford.Collections.Immutable.ArrayList)){}
}