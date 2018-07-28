using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class Test : MonoBehaviour {

	public AudioMixer audioMixer;
	public AudioMixerGroup group;
	// Use this for initialization
	void Start() {
		var listGroup = audioMixer.FindMatchingGroups("test").ToList();
		listGroup.ForEach(e => Debug.Log(e.name));
		group = listGroup[0];
	}

	// Update is called once per frame
	void Update() {
		TestClass a = null;
		a?.DebugTest();
	}

	private class TestClass {
		public void DebugTest(){
			Debug.Log("asdfbn");
		}
	}

	// private (string, int, char) TestTuple{
	// 	return "aasdf", 2, 'a';
	// }
}