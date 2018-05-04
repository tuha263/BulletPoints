using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	[SerializeField]
	private Vector2 scale;

	private Vector2 originalScale;

	private Button button;

	void Start() {
		originalScale = transform.localScale;
		scale = new Vector2(0.9f, 0.9f);
	}

	public void OnPointerEnter(PointerEventData eventData) {
		transform.localScale = scale;
	}

	public void OnPointerExit(PointerEventData eventData) {
		transform.localScale = originalScale;
	}
}