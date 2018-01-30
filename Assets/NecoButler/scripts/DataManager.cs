﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour {

	private static DataManager instance;
	public static DataManager Instance{
		get{ return instance; }
	}
	// 싱글턴.

	public int NekoCoin;
	// 현재 소지하고 있는 냥코.
	public int TouchCoin=1;
	// 터치할때마다 늘어나는 냥코.
	public int HomeLevel=1;
	// 캣타워의 레벨.
	public int AutoCoin=5;
	// 자동으로 늘어나는 냥코.
	public int curNecoCount = 1;
	// 현재 고양이 수.
	public int availableNecoCount=10;
	// 수집 가능한 고양이 수.
	public int WeaponLevel = 1;
	// 현재 고양이풀의 레벨.
	public int StageLevel = 1;
	// 떠날 수 있는 수집 스테이지 레벨.

	public int[] Neko = new int[9];

	private Text CurNekoCoinText;
	private Text AutoNekoCoinText;
	private Text TouchNekoCoinText;
	private Text AvNecoText;
	private Text CurNecoText;

	public GameObject AutoCoinObject;
	// 자동으로 늘어나는 냥코의 보여지는 오브젝트.
	public GameObject toucheffect;
	// 터치했을시 늘어나는 냥코의 보여지는 오브젝트.

	private SpriteRenderer cattower_sr;
	private Sprite cattower_sprite;
	//캣타워 업그레이드시 이미지 변환.

	private Image towerimg_ig;
	private Sprite tower_sprite;
	//캣타워 업그레이드시 캣타워 업그레이드 버튼 이미지 변환.

	private Image dogpoor_ig;
	private Sprite dogpoor_sprite;
	//강아지풀 업그레이드시 강아지풀 업그레이드 버튼 이미지 변환.

	private Image mapimg_ig;
	private Sprite mapimg_sprite;
	//맵 업그레이드시 맵 업그레이드 버튼 이미지 변환.

	public int firstdude;
	public GameObject openImg;
	// 오프닝 이미지.

	void Awake(){
		if (instance) {
			DestroyImmediate (gameObject);
			return;
		}
		instance = this;
		//DontDestroyOnLoad (gameObject);
	}

	void Start(){
		Screen.SetResolution(1080,1920,true);

		firstdude = PlayerPrefs.GetInt ("ddude");
		if (firstdude==0) {
			openImg.SetActive (true);
			firstdude++;
			PlayerPrefs.SetInt ("ddude",firstdude);

		}

		CurNekoCoinText = GameObject.Find ("CurNekoCoinText").GetComponent<Text> ();

		AvNecoText = GameObject.Find ("AvNecoText").GetComponent<Text> ();
		CurNecoText = GameObject.Find ("CurNecoText").GetComponent<Text> ();

		AvNecoText.text = "/"+ availableNecoCount.ToString ();
		CurNecoText.text = curNecoCount.ToString ();
		CurNekoCoinText.text = NekoCoin.ToString ();

		StartCoroutine (AutoNekoCoinCoroutine ());
		// 자동으로 늘어나는 냥코 코루틴.

        CatBehaviour cat = ObjectPoolManager.Instance.cat1Pool.PopObject() as CatBehaviour;
		CatBehaviour cat2= ObjectPoolManager.Instance.cat2Pool.PopObject() as CatBehaviour;
		CatBehaviour cat3 = ObjectPoolManager.Instance.cat3Pool.PopObject() as CatBehaviour;
		// 일단 그냥 팝으로 3마리 배치했음.


		cattower_sr = GameObject.Find ("cattower").GetComponent<SpriteRenderer> ();


    }

	public void UpgradeTowerBtn(){
		if (HomeLevel == 2) {
			if (NekoCoin <= 5000) {
				return;
			}
			NekoCoin -= 5000;
			CurNekoCoinText.text = NekoCoin.ToString ();
			HomeLevel++;
			AutoCoin = 15;
			availableNecoCount = 12;
			AvNecoText.text = "/" + availableNecoCount.ToString ();

			cattower_sprite = Resources.Load<Sprite> ("cattowerimg/" + "3");
			cattower_sr.sprite = cattower_sprite;

			towerimg_ig = GameObject.Find ("cattowerimg").GetComponent<Image> ();

			tower_sprite = Resources.Load<Sprite> ("main/" + "102");
			towerimg_ig.sprite = tower_sprite;
		}

		if (HomeLevel == 1) {
			if (NekoCoin <= 1000) {
				return;
			}
			NekoCoin -= 1000;
			CurNekoCoinText.text = NekoCoin.ToString ();
			HomeLevel++;
			AutoCoin = 10;
			availableNecoCount = 11;
			AvNecoText.text = "/" + availableNecoCount.ToString ();

			cattower_sprite = Resources.Load<Sprite> ("cattowerimg/" + "2");
			cattower_sr.sprite = cattower_sprite;

			towerimg_ig = GameObject.Find ("cattowerimg").GetComponent<Image> ();

			tower_sprite = Resources.Load<Sprite> ("main/" + "101");
			towerimg_ig.sprite = tower_sprite;

		}

	}

	public void UpgradeWeaponBtn(){
		if (WeaponLevel == 2) {
			if (NekoCoin <= 2000) {
				return;
			}
			NekoCoin -= 2000;
			CurNekoCoinText.text = NekoCoin.ToString ();
			WeaponLevel++;

			dogpoor_ig = GameObject.Find ("dogpoorimg").GetComponent<Image> ();

			dogpoor_sprite = Resources.Load<Sprite> ("main/" + "105");
			dogpoor_ig.sprite = dogpoor_sprite;



		}
		if (WeaponLevel == 1) {
			if (NekoCoin <= 1000) {
				return;
			}
			NekoCoin -= 1000;
			CurNekoCoinText.text = NekoCoin.ToString ();
			WeaponLevel++;

			dogpoor_ig = GameObject.Find ("dogpoorimg").GetComponent<Image> ();

			dogpoor_sprite = Resources.Load<Sprite> ("main/" + "104");
			dogpoor_ig.sprite = dogpoor_sprite;

		}

	}

	public void UpgrademapBtn(){

		if (StageLevel == 1) {
			if (NekoCoin <= 1000) {
				return;
			}
			NekoCoin -= 1000;
			CurNekoCoinText.text = NekoCoin.ToString ();
			StageLevel++;

			mapimg_ig = GameObject.Find ("mapimg").GetComponent<Image> ();

			mapimg_sprite = Resources.Load<Sprite> ("main/" + "107");
			mapimg_ig.sprite = mapimg_sprite;
		}
		
	
	}

	public void touchmybody(){
		// 화면 터치시 늘어나는 냥코 버튼.
		NekoCoin += TouchCoin;
		CurNekoCoinText.text = NekoCoin.ToString ();
		toucheffect.SetActive (true);
		TouchNekoCoinText = GameObject.Find ("TouchNekoCoinText").GetComponent<Text> ();
		TouchNekoCoinText.text = "+" + TouchCoin.ToString ();
		StartCoroutine (TouchNekoCoinCoroutine ());
	}

	/*
	public void touchpoint(){

		// 터치포인트로 터치이펙트를 넣기위해 짰던건데 이상함.

		//Vector2 pod = Input.GetTouch (0).position;
		//Vector3 thetouch = new Vector3 (pod.x, pod.y, 0);
		//Debug.Log (thetouch);
		//Vector2 asdf;
		//float aff;
		//aff= Input.GetMouseButtonDown(0)
		//asdf = Input.GetMouseButtonDown;
		//Debug.Log (asdf);
	}
*/

	IEnumerator TouchNekoCoinCoroutine(){
		// 화면 터치시 늘어나는 냥코의 수치 이미지가 떴다가 사라지는 코루틴.
		yield return new WaitForSeconds (1.5f);
		toucheffect.SetActive (false);
	}

	IEnumerator AutoNekoCoinCoroutine(){
		// 자동으로 늘어나는 냥코 코루틴.
		yield return new WaitForSeconds (3f);
		AutoCoinObject.SetActive (true);
		AutoNekoCoinText = GameObject.Find ("AutoNekoCoinText").GetComponent<Text> ();
		AutoNekoCoinText.text ="+"+ AutoCoin.ToString ();
		NekoCoin += AutoCoin;
		CurNekoCoinText.text = NekoCoin.ToString ();
		yield return new WaitForSeconds (1.5f);
		AutoCoinObject.SetActive (false);
		StartCoroutine (AutoNekoCoinCoroutine ());


	}


}
