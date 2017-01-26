using UnityEngine;
using System.Collections;

public class StarController : Entity {

	public Color color;
	public Vector3 size;
	public float type;

	private GameObject starGeo;

	// Use this for initialization
	void Start () {
		starGeo = transform.FindChild ("StarGeo").gameObject;
		Debug.Log (starGeo.name);

		type = Random.value;
		setType (type);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setType(float type) {
		Material mat = starGeo.GetComponent<MeshRenderer>().material;

		if (type <= 0.3f) {
			color.r = 1.0f;
			color.g = 0.0f;
			color.b = 0.0f;
			size = new Vector3 (5.0f, 5.0f, 5.0f);
		} else if (type > 0.3f && type <= 0.5f) {
			color.r = 0.0f;
			color.g = 0.0f;
			color.b = 1.0f;
			size = new Vector3 (2.0f, 2.0f, 2.0f);
		} else if (type > 0.5f && type <= 1.0f) {
			color.r = 1.0f;
			color.g = 1.0f;
			color.b = 0.0f;
			size = new Vector3 (3.0f, 3.0f, 3.0f);
		} else {
			color.r = 1.0f;
			color.g = 1.0f;
			color.b = 1.0f;
			size = new Vector3 (1.0f, 1.0f, 1.0f);
		}

		mat.color = color;
		transform.localScale = size;
	}

	public override void Deselect() {
		base.Deselect();
		selectionWidget.GetComponent<MeshRenderer>().enabled = false;
	}

	public override void Select() {
		base.Select();
		selectionWidget.GetComponent<MeshRenderer>().enabled = true;
	}
}//
