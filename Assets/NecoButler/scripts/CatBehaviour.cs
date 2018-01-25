using System.Collections;
using UnityEngine;

public class CatBehaviour : PoolableObject {

	private int randomAniNb;
	// 랜덤으로 애니메이션이 재생하도록 하는 변수. 비효율적이여서 수정필요.
	private int numbernumber;
	// 애니메이션 재생시 해당 애니메이션 변수.
	private float randomposNbx;
	private float randomposNby;
	private Vector3 StartPos;
	private Vector3 TargetPos;
	// 애니메이션 재생시 움직이는 곳으로 가는 힘과 타겟 포인트. 
	private float frame = 1f;
	//private int opnb0=1;
	//private int opnb1=-1;
	private Animator autoAni;
	private bool sitdownplz=false;
	// 현재 앉아있는 상태인지 체크.

	public override void Start () {
		base.Start ();
		autoAni=GetComponent<Animator> ();
		RandomAnifx ();
		// 시작하자마자 애니메이션 재생 하도록 했는데 방법 재고 필요.
		Debug.Log (Vector3.left);
	}

	void Update () {

		if (frame >= 1f) {
			return;
		}
		transform.position = (1f - frame) * StartPos + frame * TargetPos;
		//목표 포인트로 보간법으로 움직임.
		frame += Time.deltaTime*0.7f;
	}

	private void RandomAnifx(){
		// 자동으로 랜덤 애니 재생 함수.

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
		// 고양이끼리 부딪혔을시 앞에 있도록 하는건데 적용이 안돼서 다시 짜야함.

		if (col.transform.tag == "cat") {
			if (transform.position.y <= col.transform.position.y) {
				transform.SetAsFirstSibling ();
			}
		}
	}


}
