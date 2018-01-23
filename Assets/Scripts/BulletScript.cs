using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BulletScript : MonoBehaviour {

	public GameObject explosion; 
	public AudioClip impact;
	AudioSource audioSource;
	bool didExplode = false;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (!didExplode){
		audioSource.PlayOneShot(impact, 0.7F);		
		GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
		Destroy(gameObject, 0.7f);  // destroy 
		Destroy(expl, 3);
		didExplode = true;
		transform.gameObject.tag = "Player"; 

		}

}


}
