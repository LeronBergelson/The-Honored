using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour {
	public GameObject explosion; 
	[SerializeField] AudioSource aud;


	void Start () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameObject expl = Instantiate(explosion, transform.position + (new Vector3(0, 0, 0)), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
			aud.Play ();
			Destroy (gameObject);
			Destroy(expl, 3); 

			}


		}
}
