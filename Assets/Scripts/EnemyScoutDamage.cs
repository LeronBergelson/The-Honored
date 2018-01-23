using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoutDamage : MonoBehaviour {
	[SerializeField] int health;
	private EnemyShooter enemyShooter;
	public GameObject explosion; 


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Bullet") {
			health -= 1;
			if (health == 0) {
				enemyShooter.isDead = true;
				GameObject expl = Instantiate(explosion, transform.position + (new Vector3(0, 10, 0)), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
				gameObject.tag = "DeadScout";

			}


		}
	}
	void Start(){
		enemyShooter = GetComponentInChildren<EnemyShooter> ();


	}

}
