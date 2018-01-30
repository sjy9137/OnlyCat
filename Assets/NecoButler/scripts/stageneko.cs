using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageneko : MonoBehaviour {

	//고양이 획득씬에서 고양이 얻는 스크립트. 스와이프를 통해 고양이 획득.

	public GameObject stage1;
	//캔버스 1 스테이지.
	public GameObject stage2;
	//캔버스 2 스테이지.
	public GameObject[] Player = new GameObject[6];
	//스테이지 플레이시 터치해야하는 물음표 고양이.
	private int mand;
	//물음표 고양이 랜덤 변수.
	private int curcur=1;
	//현재 스테이지.

	private int patternNb;

	Touch initTouch;
	bool swipedbool = false;

	private int randrover;
	//고양이 랜덤 변수.
	private int randpat;
	public GameObject darkimage;
	public GameObject[] Weapon = new GameObject[3];
	public GameObject aniRight,aniLeft,aniUp;
	private Animator allaniani;
	private Animator buddleani;
	private bool right1bool,left1bool,up1bool;

	public GameObject winPannel;

	private Image WinNekoimg_ig;
	private Sprite WinNekoimg_sprite;

	void Start () {
		Screen.SetResolution(1080,1920,true);
		//curcur = DataManager.Instance.curstageNb;
	
		if (curcur==2) {
			stage2.SetActive (true);
			StartCoroutine (Stage2Coroutine ());
		}
		if (curcur == 1) {
			stage1.SetActive (true);
			StartCoroutine (Stage1Coroutine ());
		}


	}

	void Update(){
		SwipedFx ();
	}

	private void SwipedFx(){
		//모바일 스와이프 인식 함수.
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
						//DownBtn ();
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



	public void startthefight(){
		//물음표 고양이 눌럿을시 발동하는 함수.
		StopCoroutine (Stage1Coroutine ());
		StopCoroutine (Stage2Coroutine ());
		Player [mand].SetActive (false);

		randrover = Random.Range (0, 100);

		darkimage.SetActive (true);

		Weapon [0].SetActive (true);

		StartCoroutine (onesecondCoroutine ());
		patternNb = 1;

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

	private void WinImgChangeFx(){
		// 고양이 획득 했을 시 획득한 고양이 이미지 변환. 더 간소화 가능.
		WinNekoimg_ig = GameObject.Find("WinNekoImg").GetComponent<Image>();

		if (randrover >= 70) {
			WinNekoimg_sprite = Resources.Load<Sprite> ("etc/" + "3_sleeping");
			WinNekoimg_ig.sprite = WinNekoimg_sprite;
		} else if (randrover >= 40) {
			WinNekoimg_sprite = Resources.Load<Sprite> ("etc/" + "2_sleeping");
			WinNekoimg_ig.sprite = WinNekoimg_sprite;
		} else {
			WinNekoimg_sprite = Resources.Load<Sprite> ("etc/" + "1_sleeping");
			WinNekoimg_ig.sprite = WinNekoimg_sprite;
		}
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
				StartCoroutine(Stage1Coroutine());
			} else {
				StartCoroutine (Stage2Coroutine ());
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






	// 강아지 풀 애니메이션. 하나로 합칠 수 있을듯.
	IEnumerator leftCoroutine(){
		yield return new WaitForSeconds (0.5f);
		if (left1bool == true) {
			left1bool = false;
			if (patternNb <= 0) {
				StopCoroutine (onesecondCoroutine ());
				winPannel.SetActive (true);
				WinImgChangeFx ();
				darkimage.SetActive (false);
				Weapon [0].SetActive (false);
			}
			patternNb--;
			yield break;
		}
		darkimage.SetActive (false);
		Weapon [0].SetActive (false);
		if (stage1.activeInHierarchy) {
			StartCoroutine(Stage1Coroutine());
		} else {
			StartCoroutine (Stage2Coroutine ());
		}
	}

	IEnumerator rightCoroutine(){
		yield return new WaitForSeconds (0.5f);
		if (right1bool == true) {
			right1bool = false;
			if (patternNb <= 0) {
				StopCoroutine (onesecondCoroutine ());
				winPannel.SetActive (true);
				WinImgChangeFx ();
				darkimage.SetActive (false);
				Weapon [0].SetActive (false);
			}
			patternNb--;
			yield break;
		}
		darkimage.SetActive (false);
		Weapon [0].SetActive (false);
		if (stage1.activeInHierarchy) {
			StartCoroutine(Stage1Coroutine());
		} else {
			StartCoroutine (Stage2Coroutine ());
		}
	}

	IEnumerator upCoroutine(){
		yield return new WaitForSeconds (0.5f);

		if (up1bool == true) {
			up1bool = false;
			if (patternNb <= 0) {
				StopCoroutine (onesecondCoroutine ());
				winPannel.SetActive (true);
				WinImgChangeFx ();
				darkimage.SetActive (false);
				Weapon [0].SetActive (false);
			}
			patternNb--;
			yield break;
		}
		darkimage.SetActive (false);
		Weapon [0].SetActive (false);
		if (stage1.activeInHierarchy) {
			StartCoroutine(Stage1Coroutine());
		} else {
			StartCoroutine (Stage2Coroutine ());
		}
	}


	// 스테이지안의 물음표 고양이 뜨게하는 함수. 두개 하나로 합칠 수 있음.
	IEnumerator Stage1Coroutine(){
		mand = Random.Range (0, 3);
		Player [mand].SetActive (true);

		yield return new WaitForSeconds (4f);
		Player [mand].SetActive (false);
		float man = Random.Range (2f, 4f);
		yield return new WaitForSeconds (man);

		StartCoroutine (Stage1Coroutine ());
	}


	IEnumerator Stage2Coroutine(){
		mand = Random.Range (3,6);
		Player [mand].SetActive (true);

		yield return new WaitForSeconds (4f);
		Player [mand].SetActive (false);
		float man = Random.Range (2f,4f);
		yield return new WaitForSeconds (man);

		StartCoroutine (Stage2Coroutine ());

	}

}
