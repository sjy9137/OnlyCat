using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
	private float frame = 1f;

	private Vector3 StartPos;
	private Vector3 TargetPos;

	public GameObject UIOpenObject;
	public GameObject UICloseObject;

	public GameObject firstObject;
	public GameObject secondbject;
	public GameObject thirdObject;
	//public GameObject allObject;






	void Update () {

		if (frame >= 1f) {
			return;
		}

		transform.position = (1f - frame) * StartPos + frame * TargetPos;

		frame += Time.deltaTime*2;

	}

	public void UIOpenfx(){
		//allObject.SetActive (true);
		frame = 0f;
		StartPos = transform.position;
		TargetPos = Vector3.up*6;
		UIOpenObject.SetActive (false);
		UICloseObject.SetActive (true);
	}

	public void UIClosefx(){
	//	allObject.SetActive (false);
		frame = 0f;
		StartPos = transform.position;
		TargetPos = Vector3.zero;
		UIOpenObject.SetActive (true);
		UICloseObject.SetActive (false);
	}

	public void firstopenfx(){
		firstObject.SetActive (true);
		secondbject.SetActive (false);
		thirdObject.SetActive(false);
	}
	public void secondopenfx(){
		firstObject.SetActive (false);
		secondbject.SetActive (true);
		thirdObject.SetActive(false);


	

	}



	public void thirdopenfx(){
		firstObject.SetActive (false);
		secondbject.SetActive (false);
		thirdObject.SetActive(true);
	}


}
