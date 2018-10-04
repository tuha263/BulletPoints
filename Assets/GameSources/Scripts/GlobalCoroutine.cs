using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCoroutine : MonoBehaviour {
	public AudioHelm.AudioHelmClock clock;

	// Use this for initialization
	void Start () {
		this.clock = GameObject.Find("HelmClock").GetComponent<AudioHelm.AudioHelmClock>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
