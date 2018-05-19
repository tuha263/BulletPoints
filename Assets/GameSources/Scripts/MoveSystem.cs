using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MoveSystem : EventMediator {
	[Inject]
	public IGameStateData gameStateData { get; set; }

	[Inject]
	public MusicFieldMediator musicFieldMediator { get; set; }

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		Debug.Log(gameStateData);
		if (gameStateData != null && gameStateData.isPlaying) {
			dispatcher.Dispatch(GameEvent.OnTimeUpdate);
		}
	}
}