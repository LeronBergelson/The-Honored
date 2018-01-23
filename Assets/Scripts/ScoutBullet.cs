using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutBullet : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		Destroy(gameObject); 
	}
}
