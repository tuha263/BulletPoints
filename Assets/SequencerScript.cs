using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerScript : MonoBehaviour {

	public AudioHelm.Sequencer sequencer;

	public void PlayChord(int[] chord) {
		sequencer.Clear ();
		sequencer.length = GameControl.instance.CurrentSeqLength;
		for (int i = 0; i < chord.Length; i++) {
			int note = chord [i] + 12;
			sequencer.AddNote (note, 0, GameControl.instance.CurrentSeqLength, 1);
		}
		if (!sequencer.isActiveAndEnabled) {
			sequencer.enabled = true;
			sequencer.StartOnNextCycle ();
		}
	}
}
