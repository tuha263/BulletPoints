using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTempo : MonoBehaviour {

	public int value;
	public AudioHelm.AudioHelmClock clock;
	Slider slider;

	void Start() {
		slider = GetComponentInParent<Slider>();
	}
	public void SetTempo() {
		clock.bpm = slider.value;
	}
}
