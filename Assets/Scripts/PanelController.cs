﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {
	public float fadeInTime;
	private Image fadePanel;
	private Color currentColor = Color.black;
	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		fadePanel.color = currentColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeSinceLevelLoad < fadeInTime) {
			//Fading in
			float fadeInSpeed = Time.deltaTime/fadeInTime;
			Debug.Log(currentColor.a);
			currentColor.a -=fadeInSpeed;
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive(false);
		}
	}
}
