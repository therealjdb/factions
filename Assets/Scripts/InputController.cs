using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public CameraController cam_ctrl;

	public float zoom_speed;
	public Vector3 rot_speed;

	public Transform selection;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// RMB Held: Rotate Cam
		if (Input.GetMouseButton(1)) {
			Vector3 rDelta = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);
			cam_ctrl.RotateCamera(rot_speed, rDelta);
			Debug.Log("press");
		}
		// Wheel: Zoom
		if (Input.mouseScrollDelta.y != 0) {
			cam_ctrl.ZoomCamera(zoom_speed, Input.mouseScrollDelta.y);
		}
		// LMB Down: select
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = cam_ctrl.mainCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
					
			if (Physics.Raycast (ray, out hitInfo)) {
				SetSelection (hitInfo.collider.transform.parent);
				cam_ctrl.CameraFocus = selection;
			} else {
				SetSelection (GameObject.Find ("Nothing").transform);
			} 
		}
		//
		if (Input.GetKeyDown (KeyCode.F)) {
			cam_ctrl.setFocus (selection);
		}
	}

	public void SetSelection (Transform sel) {
		if (sel != selection) {
			selection.GetComponentInParent<Entity> ().Deselect ();
			selection = sel;
			selection.GetComponentInParent<Entity> ().Select ();
		}
	}
}
