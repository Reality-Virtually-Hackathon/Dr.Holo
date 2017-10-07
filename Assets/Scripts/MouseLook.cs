using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	//Get the main camera
	private GameObject mainCamera;
	//Mouse sensitivity 
	public float mouseSensitivity = 200f;
	//Clamps the rotation
	private float clampAngle = 80f;
	private float rotationX	= 0f;
	private float rotationY = 0f;
	//Mouse input
	private float mouseX;
	private float mouseY;
	private Quaternion localRotation;


	void Start () {
		//Only execute if on the Windows Unity Editor
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			//Find the main camera in the scene
			mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
			//Get the local rotation
			Vector3 rotationInitialize = transform.localRotation.eulerAngles;
			rotationX = rotationInitialize.x;
			rotationY = rotationInitialize.y;
		}
	}
	

	void Update () {
		//Only execute if on the Windows Unity Editor
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			//Get input axis from the mouse
			mouseX = Input.GetAxis ("Mouse X");
			mouseY = Input.GetAxis ("Mouse Y");
			//Update mouse rotation
			rotationX += mouseX * mouseSensitivity * Time.deltaTime;
			rotationY += mouseY * mouseSensitivity * Time.deltaTime;
			//Clamp the rotation
			rotationX = Mathf.Clamp (rotationX, -clampAngle, clampAngle);
			//Rotate the camera
			localRotation = Quaternion.Euler (-rotationY, rotationX, 0.0f);
			//Change the local camera rotation
			mainCamera.transform.rotation = localRotation;
		}
	}
}
