using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {	
	public AudioClip[] levelMusicChangeArray;
	private AudioSource music;

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
	}
	// Use this for initialization
	void Start ()
	{
			music = GetComponent<AudioSource> ();
	}

	void OnLevelWasLoaded (int level)
	{
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		if (thisLevelMusic) {
			music.clip = thisLevelMusic;
			if (level > 0) {
				music.loop = true;
			}else{
				music.loop = false;
			}
		Debug.Log(level+" music is  "+music.clip);
		music.Play();
		}
	}


}
