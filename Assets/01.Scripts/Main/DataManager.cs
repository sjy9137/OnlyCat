using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour {

	private static DataManager instance;
	public static DataManager Instance{
		get{ return instance; }
	}
	// 싱글턴.

	public int[] Neko = new int[3];


	void Awake(){
		if (instance) {
			DestroyImmediate (gameObject);
			return;
		}
		instance = this;
		//DontDestroyOnLoad (gameObject);
	}

	void Start(){

		Neko [0] = PlayerPrefs.GetInt ("Neko0");
		Neko [1] = PlayerPrefs.GetInt ("Neko1");
		Neko [2] = PlayerPrefs.GetInt ("Neko2");

	}

}
