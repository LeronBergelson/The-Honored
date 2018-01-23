using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

	[SerializeField] Camera camera1; 
	[SerializeField] Camera camera2; 
	[SerializeField] Camera camera3; 

	private bool switchCam = false;
	private bool backCam = false;
	private bool scopeCam = false;
	private int camSelect;
	bool click = true;

	void Start(){ 
		camSelect = 1;
		camera1.GetComponent<Camera>().enabled = true; 
		camera2.GetComponent<Camera>().enabled = false; 
		camera3.GetComponent<Camera>().enabled = false; 


	} 

	void Update() { 
		if (Input.GetKey(KeyCode.C)) {
			camera2.GetComponent<Camera>().enabled = false;
			switchCam = !switchCam; 
			backCam = false; 
			scopeCam = false; 
			camSelect = 1;


		} 

		if (Input.GetKey(KeyCode.V)){
			camera1.GetComponent<Camera>().enabled = false; 
			switchCam = false;
			backCam = true; 
			scopeCam = false; 
			camSelect = 2;

		} 
			

		if (click) {
			if (Input.GetMouseButtonDown (1)) {
				//if (Input.GetKey(KeyCode.X)){
				switchCam = false;
				backCam = false; 
				scopeCam = true; 
				click = false;
			}
		} else {
			if (Input.GetMouseButtonDown (1)) {
				{

					if (camSelect == 1) {
						switchCam = true;
						backCam = false; 
						scopeCam = false; 
					}

					if (camSelect == 2) {
						switchCam = false;
						backCam = true; 
						scopeCam = false; 
					}
					click = true;
				}
			}
		}
	

		if (switchCam == true) {
			camera1.GetComponent<Camera>().enabled = true; 
			camera2.GetComponent<Camera>().enabled = false;
			camera3.GetComponent<Camera>().enabled = false;


		} 
		else if (backCam == true) {
			camera1.GetComponent<Camera>().enabled = false; 
			camera2.GetComponent<Camera>().enabled = true; 
			camera3.GetComponent<Camera>().enabled = false; 

		} 

		else if (scopeCam == true) {
			camera1.GetComponent<Camera>().enabled = false; 
			camera2.GetComponent<Camera>().enabled = false; 
			camera3.GetComponent<Camera>().enabled = true; 

		} 


		else { 
			camera1.GetComponent<Camera>().enabled = true; 
			camera2.GetComponent<Camera>().enabled = false;
			camera3.GetComponent<Camera>().enabled = false; 

		} 
	}


}
