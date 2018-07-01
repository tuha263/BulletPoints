using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;

public class DrumSeqTestScript : MonoBehaviour {

	[SerializeField]
	private Sampler sampler;
	public SampleSequencer seq;
	[SerializeField] 
	private UnityEngine.Audio.AudioMixerGroup mixerGroup;

	// Use this for initialization
	void Start () {
		LoadDrumSounds();
		
	}

	public void LoadDrumSounds() {
		int minKey = 0;
		Object[] sampleArray = Resources.LoadAll("DrumSamples/1");
		for (int i = 0; i < sampleArray.Length; i++) {
			Keyzone keyZone = sampler.AddKeyzone();
			keyZone.minKey = minKey;
			keyZone.rootKey = minKey + 2;
			keyZone.maxKey = minKey + 4;
			keyZone.audioClip = sampleArray[i] as AudioClip;
			keyZone.mixer = mixerGroup;
			minKey += 5;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
