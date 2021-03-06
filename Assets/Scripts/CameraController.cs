using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	// MainCameraRig is the GameObject that contains the actual camera object. It is used to rotate the camera.
	private Transform MainCameraRig;
	// CameraFocus is the GameObject that the camera is currently constrained to follow.
	public Transform CameraFocus;
	// How 
	public Vector2 zoomBounds;

	// Camera is the actual Camera.
	public Camera mainCamera;
	// current_rotation is the stored rotation value used to compare against the previous frame in order to rotate the camera.
	private Vector3 current_rotation;
	// target position of the camera rig
	private Vector3 target_position;
	// when the camera started moving
	private float startTime;

	// Use this for initialization
	void Start () {
		MainCameraRig = transform;
		mainCamera = Camera.main;

		current_rotation = MainCameraRig.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		// If the focus has changed, move the camera there.
		if (transform.position != target_position) {
			float distance = Vector3.Distance(transform.position, target_position);
			transform.position = Vector3.Lerp (transform.position, target_position, ((Time.time - startTime) * 1) / distance);
		}
	}

	public void RotateCamera(Vector3 rot_speed, Vector3 rDelta) {
		// RotateCamera() rotates the MainCameraRig by rDelta degrees multiplied by rot_speed.
		current_rotation.x -= rot_speed.x * rDelta.x;
		current_rotation.y += rot_speed.y * rDelta.y;
		current_rotation.z += rot_speed.z * rDelta.z;

		MainCameraRig.eulerAngles = current_rotation;
	}

	public void ZoomCamera(float zoom_speed, float zDelta) {
		// ZoomCamera() moves the Camera along the local z axis.
		Vector3 zoom = new Vector3(0.0f, 0.0f, zDelta*zoom_speed);

		mainCamera.transform.Translate(zoom);
	}

	public void TranslateCamera(Vector3 direction) {
	
	}

	public void setFocus(Transform focus){
		//MainCameraRig.transform.position = focus.position;
		target_position = focus.transform.position;
		startTime = Time.time;
	}
}
