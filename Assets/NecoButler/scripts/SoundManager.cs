using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private static SoundManager instance;
	public static SoundManager Instance{
		get{ return instance; }

	}


	public AudioClip soundback;
	public AudioClip soundwin;
	public AudioClip soundfail;
	public AudioClip soundhunt;

	private AudioSource myAudio;
	private AudioSource winAudio;
	private AudioSource failAudio;

	void Awake(){
		if (instance) {
			DestroyImmediate (gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
	}

	void Start(){
		myAudio = GetComponent<AudioSource> ();
		myAudio.clip = soundback;
		winAudio = GetComponent<AudioSource> ();
		failAudio = GetComponent<AudioSource> ();
		myAudio.Play ();
//		myAudio.PlayOneShot (soundback);

	}

	public void ssoundfx(){

		winAudio.clip = soundwin;
		winAudio.Play ();
	}

}
