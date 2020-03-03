using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ES2UserType_SystemCollectionsDictionaryEntry : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		System.Collections.DictionaryEntry data = (System.Collections.DictionaryEntry)obj;
		// Add your writer.Write calls here.

	}
	
	public override object Read(ES2Reader reader)
	{
		System.Collections.DictionaryEntry data = new System.Collections.DictionaryEntry();

		return data;
	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_SystemCollectionsDictionaryEntry():base(typeof(System.Collections.DictionaryEntry)){}
}