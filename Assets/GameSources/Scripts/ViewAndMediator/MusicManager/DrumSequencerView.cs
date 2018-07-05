using System.Collections;
using System.Collections.Generic;
using AudioHelm;
using strange.extensions.mediation.impl;
using UnityEngine;

public class DrumSequencerView : MusicManagerView {

	[SerializeField]
	private Sampler sampler;
	[SerializeField]
	public UnityEngine.Audio.AudioMixerGroup mixerGroup;

	// Use this for initialization
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

	public override void AddNode(int collum, int index, EmoTileData emoTileData){
    sequencer.AddNote(emoTileData.note + (NodeCollumTileData.AmountOfNode - 1 - index) / 3, collum, collum + emoTileData.data.Notelength, 1);
	}
}