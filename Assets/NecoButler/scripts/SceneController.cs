using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// 거이 없어도 되는 스크립트. 씬 변경. 

	void Start(){
		Screen.SetResolution(1080,1920,true);
	}

	public void ChangeScene_Int(int SceneNumber){
		SceneManager.LoadScene (SceneNumber);
	}

}
