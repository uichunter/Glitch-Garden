using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	public float levelSeconds;
	public AudioSource audioSource;

	bool isLevelOver = false;
	GameObject nextLevelTitle;
	LvManager lvManager;

	Slider slider;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		lvManager = FindObjectOfType<LvManager>();
		FindNextLevelTitle ();
		nextLevelTitle.SetActive(false);

	}

	void FindNextLevelTitle ()
	{
		nextLevelTitle = GameObject.Find ("Next Level Title");
		if (nextLevelTitle == null) {
			Debug.LogError ("Please create a next level title.");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if (slider.value >= 1 && !isLevelOver) {
			audioSource.Play();
			isLevelOver = true;
			nextLevelTitle.SetActive(true);
			Invoke("LoadLevelUp",audioSource.clip.length);
		}
	}

	void LoadLevelUp ()
	{
		lvManager.LoadNextLv();
	}
}
