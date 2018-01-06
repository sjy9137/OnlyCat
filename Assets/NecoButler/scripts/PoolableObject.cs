using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour,IListener {

	protected ObjectPool<PoolableObject> Pool;

	public void OnEvent(EVENT_TYPE eventType, Component sender, Object param = null ){

		if (gameObject.activeInHierarchy) {
			Push ();
		}
	}
	public virtual void Start(){
		//EventManager.Instance.AddListener (EVENT_TYPE.Restart, this);
	}

	public virtual void Create (ObjectPool<PoolableObject> pool){
		Pool = pool;
		gameObject.SetActive (false);
	}

	public virtual void Push(){
		Pool.PushObject (this);
	}
}
