using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncherRotate : MonoBehaviour {
	public int horizontalSpeed = 1;

	void Update () {

		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		transform.Rotate(0, 0, h);


	}
	}


