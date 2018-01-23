using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] Transform bulletSpawn;
	[SerializeField] float bulletForce;
	public int timeBetweenShots = 1; 
	private float timestamp;

	AudioSource aud;
	// Use this for initialization
	void Start () {
		aud = this.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (Time.time >= timestamp && (Input.GetMouseButtonDown (0))){
			GameObject bulletInst = Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
			timestamp = Time.time + timeBetweenShots;
			Vector3 fwd = bulletSpawn.TransformDirection (Vector3.left);
			bulletInst.GetComponent<Rigidbody> ().AddForce (fwd * bulletForce * Time.deltaTime);
			aud.Play ();
			Destroy (bulletInst, 5);

		}


	}
}
