using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCameraController : MonoBehaviour {



	public Transform target;     //추적할 타겟 게임 오브젝트의 Transform 변수
	public float dist = 10.0f;     // 카메라와의 일정 거리
	public float height = 5.0f;     // 카메라의 높이 설정
	public float dampRotate = 5.0f;     // 부드러운 회전을 위한 변수
	public float TurnSpeed;
	public float camPos;
	Vector3 V3;
	private Transform tr;

	void Start () 
	{
		//카메라 자신의 transform 컴포넌트를 tr에 할당
		tr = GetComponent<Transform> (); 
		TurnSpeed = 2f;
		camPos = 2f;
	}

	void Update()
	{
		Vector3 PositionInfo = tr.position - target.position;     // 주인공과 카메라 사이의 백터정보
		PositionInfo = Vector3.Normalize (PositionInfo);     // 화면 확대가 너무 급격히 일어나지 않도록 정규화

		target.transform.Rotate (0, Input.GetAxis ("Horizontal")* TurnSpeed, 0);      //마우스 입력이 감지되면 오브젝트 회전
		transform.RotateAround (target.position, Vector3.right, Input.GetAxis ("Mouse Y")* TurnSpeed);     //마우스 Y(Pitch) 움직임 인지하여 화면 회전
		tr.position = tr.position - (PositionInfo * Input.GetAxis ("Mouse ScrollWheel")* TurnSpeed);     // 마우스 휠로 화면확대 축고
	}



}







	/*


// 모바일 버전
	

	public Transform charTarget;
	private Camera cameratarget;
	private Vector2 PrevPoint;

	public float moveSensitivityX = 1.0f;
	public float moveSensitivityY = 1.0f;
	public bool updateZoomSensitivity = true;
	public float orthoZoomSpeed = 0.05f;
	public float minZoom = 1.0f;
	public float maxZoom = 20.0f;
	public float perspectiveZoomSpeed =0.5f;
	private Transform tr;

	void Start(){
		tr = GetComponent<Transform> ();
		cameratarget = Camera.main;
	}

	void Update(){
		Vector3 PositionInfo = tr.position - charTarget.position;
		PositionInfo = Vector3.Normalize (PositionInfo);

		if (updateZoomSensitivity) {
			moveSensitivityX = cameratarget.orthographicSize / 5.0f;
			moveSensitivityY = cameratarget.orthographicSize / 5.0f;
		}
		Touch[] touches = Input.touches;
		if (cameratarget)
		{
			if (Input.touchCount == 1) {
				if (Input.GetTouch (0).phase == TouchPhase.Moved) {
					PrevPoint = Input.GetTouch (0).position - Input.GetTouch (0).deltaPosition;

					charTarget.transform.Rotate (0, -(Input.GetTouch (0).position.x - PrevPoint.x), 0);
					cameratarget.transform.RotateAround (charTarget.position, Vector3.right, -(Input.GetTouch (0).position.y - PrevPoint.y)*0.5f);

					PrevPoint = Input.GetTouch (0).position;
				}
			}
		}
		if (cameratarget) {
			if (Input.touchCount == 2) 
			{
				Touch touchZero = Input.GetTouch(0);
				Touch touchOne = Input.GetTouch(1);

				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

				float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;

				tr.position = tr.position - -(PositionInfo * deltaMagnitudediff * orthoZoomSpeed);
			}
		}
	}*/

	