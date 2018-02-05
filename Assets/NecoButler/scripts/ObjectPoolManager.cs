using System.Collections;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour{

	// 오브젝트풀 매니저. 고양이들 풀링.

	private static ObjectPoolManager instance;
	public static ObjectPoolManager Instance{
		get{ return instance; }
	}

	public CatBehaviour catPref1;
	public ObjectPool<PoolableObject> catPool1;
	public CatBehaviour catPref2;
	public ObjectPool<PoolableObject> catPool2;
	public CatBehaviour catPref3;
	public ObjectPool<PoolableObject> catPool3;

	void Awake(){

		if (instance) {

			DestroyImmediate (gameObject);
			return;
		}
		instance = this;
	}

	void Start(){
		catPool1 = new ObjectPool<PoolableObject> (10, () => {
			CatBehaviour temp = Instantiate (catPref1);
			temp.transform.SetParent (transform);
			temp.Create(catPool1);
			return temp;
		});
		catPool1.Allocate ();

		catPool2 = new ObjectPool<PoolableObject> (10, () => {
			CatBehaviour temp = Instantiate (catPref2);
			temp.transform.SetParent (transform);
			temp.Create(catPool2);
			return temp;
		});
		catPool2.Allocate ();

		catPool3 = new ObjectPool<PoolableObject> (10, () => {
			CatBehaviour temp = Instantiate (catPref3);
			temp.transform.SetParent (transform);
			temp.Create(catPool3);
			return temp;
		});
		catPool3.Allocate ();
	}


}
