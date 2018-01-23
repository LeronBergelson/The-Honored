using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {
	private Transform target;
	public float range = 15f;
	[SerializeField] GameObject player;
	public Transform partToRotate;
	public float turnSpeed = 10f;
	public float timeBetweenShots = 0.5f; 
	private float timestamp;
	public bool isDead = false;

	//Enemy Bullet Spawn
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] Transform bulletSpawn;
	[SerializeField] float bulletForce;

	AudioSource aud;


	void Start () {
		InvokeRepeating ("updateTarget", 0f, 0.5f);
		aud = this.GetComponent<AudioSource> ();

	}

	void updateTarget(){

		float distanceToEnemy = Vector3.Distance (transform.position, player.transform.position);

		if (distanceToEnemy > range) {
			target = null;

		}
		if (distanceToEnemy <= range) {
			target = player.transform;

		}
	}
	void Update () {
		if (target == null || isDead)
			return;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0, rotation.y, 0f);

		if (Time.time >= timestamp){
			GameObject bulletInst = Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
			timestamp = Time.time + timeBetweenShots;
			Vector3 fwd = bulletSpawn.TransformDirection (Vector3.forward);
			bulletInst.GetComponent<Rigidbody> ().AddForce (fwd * bulletForce * Time.deltaTime);
			aud.Play ();
			Destroy (bulletInst, 5);

		}

	}

	void Shoot(){
		Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
