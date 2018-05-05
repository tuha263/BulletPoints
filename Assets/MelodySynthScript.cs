using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodySynthScript : MonoBehaviour {
	
	public AudioHelm.HelmSequencer sequencer;
	int[] notes;
	float[] weights;
	int[] rhythms = new int[] {1, 2, 3, 4, 6};
	bool lastNoteWasSixteenth = false;

	void Start() {
		notes = new int[] { 0 };
		weights = new float[] { 0 };
	}

	public void SetNotesAndWeights (int[] notes, float[] weights) {
		this.notes = notes;
		this.weights = weights;
	}

	public void Play() {
		fillInSequence ();
	}

	void fillInSequence() {
		sequencer.Clear ();
		sequencer.length = GameControl.instance.CurrentSeqLength * 4;
		int beat = 0;
		int noteLength;
		while (beat < sequencer.length) {
			noteLength = GetRandomRhythm ();
			sequencer.AddNote (weightedChooseNote (), beat, beat + noteLength, 1);
			beat += noteLength;
			print (beat);
		}
	}

	int GetRandomRhythm() {
		if (lastNoteWasSixteenth) {
			lastNoteWasSixteenth = false;
			return 1;
		}
		int div = rhythms[Random.Range(0,rhythms.Length)];
		if (div == 1 || div == 3) {
			lastNoteWasSixteenth = true;
		}
		return div;
	}

	int weightedChooseNote() {
		int result = -1;
		while (result == -1) {
			for (int i = 0; i < notes.Length; i++) {
				float randomNumber = Random.Range (0f, 1f);
				if (randomNumber < weights [i]) {
					result = notes [i];
				}
			}
		}
		return result;
	}
}