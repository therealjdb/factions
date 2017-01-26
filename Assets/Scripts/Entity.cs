using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public bool selected = false;
	public GameObject selectionWidget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Deselect() {
		selected = false;
		Debug.Log ("entity deselect: " + name);
	}

	public virtual void Select() {
		selected = true;
		Debug.Log ("entity select: " + name);
	}
}
