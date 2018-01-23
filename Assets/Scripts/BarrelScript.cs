using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour {
	public float range = 30f;
	[SerializeField] GameObject player;
	public GameObject explosion; 
	private bool didExplode = false;
	private PlayerScript playerInfo;
	public float distanceCalc;

	void OnTriggerEnter(Collider other) {

		if (other.tag == "EnemyBullet") {
			didExplode = true;
			GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy(expl, 3); 
			Destroy (gameObject,0.1f);

		}

		if (other.tag == "Bullet") {
			didExplode = true;
			GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy(expl, 3); 
			Destroy (gameObject,0.1f);

		}


		if (other.tag == "EnemyRifleBullet") {
			didExplode = true;
			GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy(expl, 3); 
			Destroy (gameObject,0.1f);

		}

	}
		
	// Use this for initialization
	void Start () {
		playerInfo = player.GetComponent<PlayerScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		float distanceToPlayer = Vector3.Distance (transform.position, player.transform.position);
		distanceCalc = distanceToPlayer;
		if (distanceToPlayer <= range && didExplode) {
			playerInfo.health -= 5.0f;
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}

}
