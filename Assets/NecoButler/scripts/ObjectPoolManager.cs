using System.Collections;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour{

	// 오브젝트풀 매니저. 고양이들 풀링.

	private static ObjectPoolManager instance;
	public static ObjectPoolManager Instance{
		get{ return instance; }
	}

	public CatBehaviour cat1Pref;
	public ObjectPool<PoolableObject> cat1Pool;
	public CatBehaviour cat2Pref;
	public ObjectPool<PoolableObject> cat2Pool;
	public CatBehaviour cat3Pref;
	public ObjectPool<PoolableObject> cat3Pool;

	void Awake(){

		if (instance) {

			DestroyImmediate (gameObject);
			return;
		}
		instance = this;
	}

	void Start(){
		cat1Pool = new ObjectPool<PoolableObject> (10, () => {
			CatBehaviour temp = Instantiate (cat1Pref);
			temp.transform.SetParent (transform);
			temp.Create(cat1Pool);
			return temp;
		});
		cat1Pool.Allocate ();

		cat2Pool = new ObjectPool<PoolableObject> (10, () => {
			CatBehaviour temp = Instantiate (cat2Pref);
			temp.transform.SetParent (transform);
			temp.Create(cat2Pool);
			return temp;
		});
		cat2Pool.Allocate ();

		cat3Pool = new ObjectPool<PoolableObject> (10, () => {
			CatBehaviour temp = Instantiate (cat3Pref);
			temp.transform.SetParent (transform);
			temp.Create(cat3Pool);
			return temp;
		});
		cat3Pool.Allocate ();
	}


}
