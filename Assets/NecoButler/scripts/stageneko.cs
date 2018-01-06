using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageneko : MonoBehaviour {

	//고양이 획득씬에서 고양이 얻는 스크립트. 스와이프를 통해 고양이 획득.

	public GameObject stage1;
	public GameObject stage2;
	public GameObject[] Player = new GameObject[6];
	private int mand;

	private int curcur=2;

	private int patternNb;

	Touch initTouch;
	bool swipedbool = false;

	private int randrover;
	private int randpat;
	public GameObject darkimage;
	public GameObject[] Weapon = new GameObject[3];
	public GameObject aniRight,aniLeft,aniUp;
	private Animator allaniani;
	private Animator buddleani;
	private bool right1bool,left1bool,up1bool;

	public GameObject CanvasObject;

	public GameObject winPannel;

	void Start () {
		Screen.SetResolution(1080,1920,true);
	
		//curcur = DataManager.Instance.curstageNb;

		if (curcur>=2) {

			stage2.SetActive (true);

			StartCoroutine (twowaitCoroutine ());
			return;
		}

	
		stage1.SetActive (true);

		StartCoroutine(waitwaitwaitCoroutine());
	}

	void Update(){
		foreach (Touch p in Input.touches) {
			if (p.phase == TouchPhase.Began) {
				initTouch = p;
			} else if (p.phase == TouchPhase.Moved && !swipedbool) {
				float xMoved = initTouch.position.x - p.position.x;
				float yMoved = initTouch.position.y - p.position.y;
				float distace = Mathf.Sqrt ((xMoved * xMoved) + (yMoved * yMoved));
				bool swipedLeft = Mathf.Abs (xMoved) > Mathf.Abs (yMoved);

				if (distace > 50f) {
					if (swipedLeft && xMoved > 0) {
						LeftBtn ();
					} else if (swipedLeft && xMoved < 0) {
						RightBtn ();
					} else if (swipedLeft == false && yMoved > 0) {
						DownBtn ();
					} else if (swipedLeft == false && yMoved < 0) {
						UpBtn ();
					}
					swipedbool = true;
				}
			} else if (p.phase == TouchPhase.Ended) {
				initTouch = new Touch ();
				swipedbool = false;
			}

		}
	}


	public void btnbtnbtn(){
		aniUp.SetActive(true);
		allaniani = GameObject.Find ("direction_up").GetComponent<Animator> ();
		allaniani.Play ("gamejumani");
		StartCoroutine (onesecondCoroutine ());
	}

	IEnumerator onesecondCoroutine(){
		randpat = Random.Range (0, 3);

		yield return new WaitForSeconds (2f);
		if (right1bool || left1bool || up1bool == true) {
			darkimage.SetActive (false);
			Weapon [0].SetActive (false);
			right1bool = false;
			left1bool = false;
			up1bool = false;
			if (stage1.activeInHierarchy) {
				StartCoroutine(waitwaitwaitCoroutine());
			} else {
				StartCoroutine (twowaitCoroutine ());
			}

			yield break;
		}

		yield return new WaitForSeconds (0.5f);
		if (randpat == 0) {
			left1bool = true;
			aniLeft.SetActive (true);
			allaniani = GameObject.Find ("direction_left").GetComponent<Animator> ();
			allaniani.Play ("gamejumani");


		} else if (randpat == 1) {
			up1bool = true;
			aniUp.SetActive (true);
			allaniani = GameObject.Find ("direction_up").GetComponent<Animator> ();
			allaniani.Play ("gamejumani");
		} else {
			right1bool = true;
			aniRight.SetActive (true);
			allaniani = GameObject.Find ("direction_right").GetComponent<Animator> ();
			allaniani.Play ("gamejumani");

		}


		yield return new WaitForSeconds (1.3f);
		aniUp.SetActive (false);
		aniLeft.SetActive (false);
		aniRight.SetActive (false);

		StartCoroutine (onesecondCoroutine ());
	}

	public void startthefight(){
		StopCoroutine (waitwaitwaitCoroutine ());
		StopCoroutine (twowaitCoroutine ());
		Player [mand].SetActive (false);

		randrover = Random.Range (0, 100);

		CanvasObject.SetActive (true);
		darkimage.SetActive (true);

		Weapon [0].SetActive (true);

		StartCoroutine (onesecondCoroutine ());
		patternNb = 3;

		/*
		if (curcur == 1) {
			if (randrover <= 70) {
				patternNb = 2;

			} else {
				patternNb = 6;
			}
		}

		if (curcur == 2) {
			if (randrover <= 50) {
				patternNb = 4;

			} else if (randrover<=80){
				patternNb = 6;
			}else{
				patternNb = 6;
			}

		}
*/
		Debug.Log ("!");

	}
	IEnumerator leftCoroutine(){
		yield return new WaitForSeconds (0.5f);
		if (left1bool == true) {
			left1bool = false;
			if (patternNb <= 0) {
				StopCoroutine (onesecondCoroutine ());
				winPannel.SetActive (true);
				darkimage.SetActive (false);
				Weapon [0].SetActive (false);
			}
			patternNb--;
			yield break;
		}
		darkimage.SetActive (false);
		Weapon [0].SetActive (false);
		if (stage1.activeInHierarchy) {
			StartCoroutine(waitwaitwaitCoroutine());
		} else {
			StartCoroutine (twowaitCoroutine ());
		}
	}
	IEnumerator rightCoroutine(){
		yield return new WaitForSeconds (0.5f);
		if (right1bool == true) {
			right1bool = false;
			if (patternNb <= 0) {
				StopCoroutine (onesecondCoroutine ());
				winPannel.SetActive (true);
				darkimage.SetActive (false);
				Weapon [0].SetActive (false);
			}
			patternNb--;
			yield break;
		}
		darkimage.SetActive (false);
		Weapon [0].SetActive (false);
		if (stage1.activeInHierarchy) {
			StartCoroutine(waitwaitwaitCoroutine());
		} else {
			StartCoroutine (twowaitCoroutine ());
		}
	}

	IEnumerator upCoroutine(){
		yield return new WaitForSeconds (0.5f);

		if (up1bool == true) {
			up1bool = false;
			if (patternNb <= 0) {
				StopCoroutine (onesecondCoroutine ());
				winPannel.SetActive (true);
				darkimage.SetActive (false);
				Weapon [0].SetActive (false);
			}
			patternNb--;
			yield break;
		}
		darkimage.SetActive (false);
		Weapon [0].SetActive (false);
		if (stage1.activeInHierarchy) {
			StartCoroutine(waitwaitwaitCoroutine());
		} else {
			StartCoroutine (twowaitCoroutine ());
		}
	}
	public void LeftBtn(){
		buddleani = GameObject.Find ("buddle1").GetComponent<Animator> ();
		buddleani.Play ("left");
		StartCoroutine (leftCoroutine ());


	}

	public void RightBtn(){
		buddleani = GameObject.Find ("buddle1").GetComponent<Animator> ();
		buddleani.Play ("right");
		StartCoroutine (rightCoroutine ());
	}

	public void UpBtn(){
		buddleani = GameObject.Find ("buddle1").GetComponent<Animator> ();
		buddleani.Play ("up");
		StartCoroutine (upCoroutine ());
	}


	private void DownBtn(){
		darkimage.SetActive (false);
		Weapon [0].SetActive (false);
		if (stage1.activeInHierarchy) {
			StartCoroutine(waitwaitwaitCoroutine());
		} else {
			StartCoroutine (twowaitCoroutine ());
		}
	}







	IEnumerator patternCoroutine(){
		if (patternNb <= 0) {
			yield break;
		}

		yield return new WaitForSeconds (3f);
		int yoonji = Random.Range (0, 3);
		if (yoonji == 0) {
			aniUp.SetActive (true);

		}
	}



	IEnumerator waitwaitwaitCoroutine(){
				mand = Random.Range (0,3);
				Player [mand].SetActive (true);

		yield return new WaitForSeconds (4f);
		Player [mand].SetActive (false);
		float man = Random.Range (2f, 4f);
		yield return new WaitForSeconds (man);

		StartCoroutine (waitwaitwaitCoroutine ());
	}

	IEnumerator twowaitCoroutine(){
		mand = Random.Range (3,6);
		Player [mand].SetActive (true);

		yield return new WaitForSeconds (4f);
		Player [mand].SetActive (false);
		float man = Random.Range (2f,4f);
		yield return new WaitForSeconds (man);

		StartCoroutine (twowaitCoroutine ());

	}
}
