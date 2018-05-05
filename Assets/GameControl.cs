using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
	public static GameControl instance;

	int[] chord1, chord2, chord3, chord4, chord5, chord6;
	int[][] chords;
	public int CurrentSeqLength;
	int[] seqLengths;
	public int[] CurrentChord;
	public int[] LastUpdateChord;

	public MelodySynthScript melodySynthScript;
	public SequencerScript sequencerScript;
	public BassSynthScript bassSynthScript;

	public AudioHelm.HelmSequencer referenceSequencer;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start() {
		referenceSequencer.beatEvent.AddListener (QuantizedUpdateSynths);

		chord1 = new int[] {59,66,70,73,78};
		chord2 = new int[] {63,71,75,80,76};
		chord3 = new int[] {64,68,73,76,76};
		chord4 = new int[] {64,68,73,75,76};
		chord5 = new int[] {61,64,69,73,80};
		chord6 = new int[] {57,66,69,73,78};
		chords = new int[][] {chord1, chord2, chord3, chord4, chord5, chord6};

		CurrentChord = chords [0];
		ChangeChord (0);

		seqLengths = new int[] {6,8,12,16,18,20,24};
		CurrentSeqLength = GetRandomSequenceLength();

//		melodySynthScript.Play ();
		bassSynthScript.SetNotes (CurrentChord);
//		sequencerScript.PlayChord (0);
	}

	int GetRandomSequenceLength() {
		int rand = Random.Range (0, seqLengths.Length - 1);
		return seqLengths [rand];
	}

	public int[][] GetChords() {
		return chords;
	}

	float[] getMelodyNoteWeightsForChord(int[] chord) {
		return new float[] {0.2f,0.2f,0.2f,0.2f,0.2f,0.2f,0.2f,0.2f,0.2f,0.2f};
	}

	int[] ChordWithPassingTones(int[] chord) {
		int[] passingTones = new int[] {73,75,76,80,83};
		int[] newChord = new int[10];
		for (int i = 0; i < newChord.Length; i++) {
			if (i < chord.Length) {
				newChord [i] = chord [i];
			} else {
				newChord [i] = passingTones [i - 5];
			}
		}
		return newChord;
	}

	void QuantizedUpdateSynths(int beat) {
		if (beat != CurrentSeqLength - 1) {
			return;
		}
		if (CurrentChord != LastUpdateChord) {
			bassSynthScript.SetNotes (CurrentChord);

			int[] melodyNotes = ChordWithPassingTones (CurrentChord);
			melodySynthScript.SetNotesAndWeights (melodyNotes,getMelodyNoteWeightsForChord (CurrentChord));
			melodySynthScript.Play ();

			sequencerScript.PlayChord (CurrentChord);

			LastUpdateChord = CurrentChord;
		}
	}

	public void ChangeChord(int chordIndex) {
		CurrentChord = chords [chordIndex];
	}
}
