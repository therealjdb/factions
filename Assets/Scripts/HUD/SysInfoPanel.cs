using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SysInfoPanel : MonoBehaviour {

	public InputController inputCtrl;

	public Text nameField;
	public Text typeField;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		nameField.text = inputCtrl.selection.name;

		if (inputCtrl.selection.gameObject.GetComponent<StarController>()) {
			typeField.text = "" + inputCtrl.selection.gameObject.GetComponent<StarController>().type;
		} else {
			typeField.text = "";
		}
	}
}