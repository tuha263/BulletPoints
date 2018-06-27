using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;

public class DrumSequencerScript : MonoBehaviour {

	public Sampler sampler;
	public UnityEngine.Audio.AudioMixerGroup mixerGroup;

	// Use this for initialization
	void Start () {
		LoadDrumSounds();
	}
	
	public void LoadDrumSounds() {
		int minKey = 0;
		Object[] sampleArray = Resources.LoadAll("DrumSamples/1");
		for (int i = 0; i < sampleArray.Length; i++)
		{
			Keyzone keyZone = sampler.AddKeyzone();
			keyZone.minKey = minKey;
			keyZone.rootKey = minKey + 2;
			keyZone.maxKey = minKey + 4;
			keyZone.audioClip = sampleArray[i] as AudioClip;
			keyZone.mixer = mixerGroup;
			minKey += 5;			
		}
	}
}
