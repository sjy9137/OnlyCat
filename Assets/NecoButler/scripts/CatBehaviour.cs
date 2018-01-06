using System.Collections;
using UnityEngine;

public class CatBehaviour : PoolableObject {

	private int randomAniNb;
	private int numbernumber;
	private float randomposNbx;
	private float randomposNby;
	private float frame = 1f;
	private Vector3 StartPos;
	private Vector3 TargetPos;
	//private int opnb0=1;
	//private int opnb1=-1;
	private Animator autoAni;
	private bool sitdownplz=false;

	public override void Start () {
		base.Start ();
		autoAni=GetComponent<Animator> ();
		RandomAnifx ();
		Debug.Log (Vector3.left);
	}

	void Update () {

		if (frame >= 1f) {
			return;
		}
		transform.position = (1f - frame) * StartPos + frame * TargetPos;
		frame += Time.deltaTime*0.7f;
	}

	private void RandomAnifx(){
		randomAniNb = Random.Range (0, 25);	

		if (randomAniNb <= 10) {
			numbernumber = 6;
			transform.localScale = new Vector3 (1, 1, 1);
			autoAni.Play(("cat"+numbernumber).ToString());
			return;
		}if (randomAniNb <= 14) {
			numbernumber = 3;
			transform.localScale = new Vector3 (1, 1, 1);
			autoAni.Play(("cat"+numbernumber).ToString());
			return;
		}if (randomAniNb <= 18) {
			numbernumber = 5;
			transform.localScale = new Vector3 (1, 1, 1);
			movejumpfx ();
			autoAni.Play(("cat"+numbernumber).ToString());
			return;
		}if (randomAniNb <= 19) {
			numbernumber = 4;
			transform.localScale = new Vector3 (1, 1, 1);
			autoAni.Play(("cat"+numbernumber).ToString());
			return;
		}if (randomAniNb <= 22) {
			numbernumber = 2;
			transform.localScale = new Vector3 (1, 1, 1);
			moverightfx ();
			autoAni.Play(("cat"+numbernumber).ToString());
			return;
		}
		if (randomAniNb <= 25) {
			numbernumber = 1;
			transform.localScale = new Vector3 (-1, 1, 1);
			moverightfx ();
			autoAni.Play(("cat"+numbernumber).ToString());
		}
	}

	private void moverightfx(){
		frame = 0f;
		randomposNbx = Random.Range (-5f, 5f);
		randomposNby = Random.Range (-10f, 10f);
		StartPos = transform.position;
		TargetPos = new Vector3 (randomposNbx, randomposNby, 0);
	}

	private void movejumpfx(){
		if (sitdownplz==true) {
			RandomAnifx ();
			return;
		}
		frame = 0f;
		StartPos = transform.position;
		TargetPos = new Vector3 (-1.3f,2.88f,90);
		sitdownplz = true;	
	
	}

	private void movenofx(){
		numbernumber = 4;
		transform.localScale = new Vector3 (1, 1, 1);
		autoAni.Play(("cat"+numbernumber).ToString());
	}

	private void movedownfx(){
		RandomAnifx ();
		sitdownplz = false;

	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "cat") {
			if (transform.position.y <= col.transform.position.y) {
				transform.SetAsFirstSibling ();
			}
		}
	}


}
