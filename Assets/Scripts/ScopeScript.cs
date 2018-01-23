using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeScript : MonoBehaviour {

	public Canvas Canvasorg;
	bool click = true;


	void Start(){
		Canvasorg.enabled = false;

	}
	//Updat is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.V)){
			Canvasorg.enabled = false;
		} 

		if (Input.GetKey(KeyCode.C)){
			Canvasorg.enabled = false;
		} 
			
		if (click) {
			if (Input.GetMouseButtonDown (1)) {
				click = false;
				Canvasorg.enabled = true;

			}
		} else {
			if (Input.GetMouseButtonDown (1)) {
				{
					click = true;
					Canvasorg.enabled = false;

				}
			}
		}
	}
}

