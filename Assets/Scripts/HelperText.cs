using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperText : MonoBehaviour {
	public GameObject helpText;
	public bool isTriggered;
	private float time = 3;


	void Update(){
		//Debug.Log (time);
	}
	void StartCoundownTimer()
	{
		if(isTriggered){
			InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
		}
		}


	void UpdateTimer()
	{
		if (isTriggered) {
			time -= Time.deltaTime;
			if (time <= 0) {
				CancelInvoke(); // Stops all repeating invokes
				helpText.SetActive (true);
			}
		}
		}


	void OnTriggerEnter(Collider other) {
		isTriggered = true;
		StartCoundownTimer ();


}

	void OnTriggerExit(Collider other){
		isTriggered = false;
		time = 3;
		helpText.SetActive(false);

	}

	}