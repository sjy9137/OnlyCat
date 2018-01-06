using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour {

	private static DataManager instance;
	public static DataManager Instance{
		get{ return instance; }
	}

	public int NekoCoin;


	public int TouchCoin=1;



	public int HomeLevel=1;
	public int AutoCoin=5;
	public int curNecoCount = 1;
	public int availableNecoCount=10;
	public int WeaponLevel = 1;
	public int StageLevel = 1;
	public int curstageNb;

	private Vector3 pos;

	private Text CurNekoCoinText;
	private Text AutoNekoCoinText;
	private Text TouchNekoCoinText;
	private Text AvNecoText;
	private Text CurNecoText;

	public GameObject AutoCoinObject;
	public GameObject toucheffect;


	private GameObject cattowerobject;
	private SpriteRenderer cattower_sr;
	private Sprite cattower_sprite;

	private GameObject towerimg;
	private Image towerimg_ig;
	private Sprite tower_sprite;

	private GameObject dogpoor;
	private Image dogpoor_ig;
	private Sprite dogpoor_sprite;

	private GameObject mapimg;
	private Image mapimg_ig;
	private Sprite mapimg_sprite;

	public int firstdude;
	public GameObject openImg;

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
        CatBehaviour cat = ObjectPoolManager.Instance.cat1Pool.PopObject() as CatBehaviour;
		CatBehaviour cat2= ObjectPoolManager.Instance.cat2Pool.PopObject() as CatBehaviour;
		CatBehaviour cat3 = ObjectPoolManager.Instance.cat3Pool.PopObject() as CatBehaviour;


		cattowerobject = GameObject.Find ("cattower");
		cattower_sr = GameObject.Find ("cattower").GetComponent<SpriteRenderer> ();


    }

	public void UpgradeTowerBtn(){
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
			towerimg = GameObject.Find ("cattowerimg");
			towerimg_ig = GameObject.Find ("cattowerimg").GetComponent<Image> ();

			tower_sprite = Resources.Load<Sprite> ("main/" + "101");
			towerimg_ig.sprite = tower_sprite;

		}
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
			towerimg = GameObject.Find ("cattowerimg");
			towerimg_ig = GameObject.Find ("cattowerimg").GetComponent<Image> ();

			tower_sprite = Resources.Load<Sprite> ("main/" + "102");
			towerimg_ig.sprite = tower_sprite;
		}
	}

	public void UpgradeWeaponBtn(){
		if (WeaponLevel == 1) {
			if (NekoCoin <= 1000) {
				return;
			}
			NekoCoin -= 1000;
			CurNekoCoinText.text = NekoCoin.ToString ();
			WeaponLevel++;

			dogpoor = GameObject.Find ("dogpoorimg");
			dogpoor_ig = GameObject.Find ("dogpoorimg").GetComponent<Image> ();

			dogpoor_sprite = Resources.Load<Sprite> ("main/" + "104");
			dogpoor_ig.sprite = dogpoor_sprite;

		}
		if (WeaponLevel == 2) {
			if (NekoCoin <= 2000) {
				return;
			}
			NekoCoin -= 2000;
			CurNekoCoinText.text = NekoCoin.ToString ();
			WeaponLevel++;

			dogpoor = GameObject.Find ("dogpoorimg");
			dogpoor_ig = GameObject.Find ("dogpoorimg").GetComponent<Image> ();

			dogpoor_sprite = Resources.Load<Sprite> ("main/" + "105");
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

			mapimg = GameObject.Find ("mapimg");
			mapimg_ig = GameObject.Find ("mapimg").GetComponent<Image> ();

			mapimg_sprite = Resources.Load<Sprite> ("main/" + "107");
			mapimg_ig.sprite = mapimg_sprite;
		}
		
	
	}

	public void touchmybody(){
		NekoCoin += TouchCoin;
		CurNekoCoinText.text = NekoCoin.ToString ();
		toucheffect.SetActive (true);
		TouchNekoCoinText = GameObject.Find ("TouchNekoCoinText").GetComponent<Text> ();
		TouchNekoCoinText.text = "+" + TouchCoin.ToString ();
		StartCoroutine (TouchNekoCoinCoroutine ());
	}


	public void touchpoint(){
		//Vector2 pod = Input.GetTouch (0).position;
		//Vector3 thetouch = new Vector3 (pod.x, pod.y, 0);
	//	Debug.Log (thetouch);
		//Vector2 asdf;
		//float aff;
		//aff= Input.GetMouseButtonDown(0)
		//asdf = Input.GetMouseButtonDown;
		//Debug.Log (asdf);
	}

	IEnumerator TouchNekoCoinCoroutine(){
		yield return new WaitForSeconds (1.5f);
		toucheffect.SetActive (false);
	}

	IEnumerator AutoNekoCoinCoroutine(){

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
