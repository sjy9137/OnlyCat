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

	private RectTransform botUI_RectTransform;
	private float botUI_XAis, botUI_YAis;



	void Update () {

		if (frame >= 1f) {
			return;
		}

		transform.position = (1f - frame) * StartPos + frame * TargetPos;

		frame += Time.deltaTime*2;

	}

	public void practicefx(){

	//	gameObject.GetComponent<RectTransform> ().localPosition = new Vector4 (0, -172.78f, 0,497.78wf);

	//	botUI_RectTransform.localPosition =Vector4.zero;

	//	botUI_XAis = GUI.HorizontalSlider (new Rect (0, -162.5f, 0, 162.5f), botUI_XAis, 0, 0);
		Debug.Log("1");
			//botUI_RectTransform.anchoredPosition = new Vector3 (0, -162,0);
	//	botUI_RectTransform.localPosition = new Vector3(0, -30,0);
		//botUI_RectTransform.rect= new Vector4 (0, -162.5f, 0, 162.5f);

	}


	public void UIOpenfx(){
		gameObject.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (0, 133f, 0);
		//allObject.SetActive (true);
	//	frame = 0f;
		//StartPos = transform.position;
		//TargetPos = Vector3.up*6;
		//UIOpenObject.SetActive (false);
		//UICloseObject.SetActive (true);
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
