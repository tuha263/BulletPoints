using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioHelm;

public class Test_MasterControlScript : MonoBehaviour {

	public HelmSequencer[] synths;
	public AudioHelm.HelmController[] controllers;
	public HelmPatch[] patches;
	public AudioHelmClock clock;
	public SampleSequencer drumSeq;

	// Use this for initialization
	void Start () {
		drumSeq.enabled = false;
		for (int i = 0; i < controllers.Length; i++)
		{
			synths[i].enabled = false;
			HelmPatch patch = patches[i];
			patch.patchData.settings.polyphony = 1;
			controllers[i].LoadPatch(patches[i]);
		}
		// patch.patchData.settings.polyphony = 1;
		StartCoroutine(StartSynths());
	}
	
	IEnumerator StartSynths() {
		yield return new WaitForSeconds(2f);
		foreach (var synth in synths)
		{
			synth.enabled = true;
		}
		drumSeq.enabled = true;
		
	}
}
