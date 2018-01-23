using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public Transform canvas;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Cursor.visible = true;


			} else {
				canvas.gameObject.SetActive (false);
				Cursor.visible = false;

			}
	}
}
}