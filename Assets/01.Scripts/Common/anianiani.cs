using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anianiani : MonoBehaviour {


	public Animator ani;
	private int count =0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeAnimatorfx(){
		count++;
		Debug.Log (count);
		if (count % 2 == 0) {
			ani.SetBool ("Run", true);
		} else {
			ani.SetBool ("Run", false);
		}
	}
}
