using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassSynthScript : MonoBehaviour {

	public AudioHelm.HelmSequencer sequencer;

	public void SetNotes(int[] notes) {
		sequencer.length = GameControl.instance.CurrentSeqLength;
		sequencer.Clear ();
		sequencer.AddNote (notes [0], 0, GameControl.instance.CurrentSeqLength, 1);
	}
}
