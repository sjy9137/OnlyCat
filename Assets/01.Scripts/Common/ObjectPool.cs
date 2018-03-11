using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : PoolableObject {

	private int allocateCount;
	public delegate T Initializer();
	private Initializer initializer;
	private Stack<T> stack;
	private List<T> list;


	public ObjectPool (int ac, Initializer fn){
		allocateCount = ac;
		initializer = fn;
		stack = new Stack<T> ();
		list = new List<T> ();
	}

	public void Allocate(){
		for (int i = 0; i < allocateCount; i++) {
			stack.Push (initializer ());
		}
	}

	public T PopObject(){
		if (stack.Count <= 0) {
			Allocate ();
		}
		T obj = stack.Pop ();
		list.Add (obj);

		obj.gameObject.SetActive (true);

		return obj;
	}

	public void PushObject(T obj){
		obj.gameObject.SetActive (false);

		list.Remove (obj);
		stack.Push (obj);
	}

}
