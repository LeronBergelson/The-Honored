using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour {
	public Slider healthBar;
	[SerializeField] float movementSpeed = 5;
	[SerializeField] AudioSource movingCar;
	[SerializeField] AudioSource idleSound;
	bool isMoving = false;
	public float health;
	[SerializeField] float maxhealth;
	public GameObject explosion; 
	[SerializeField] string levelToLoad;

	[SerializeField] private Transform player;
	[SerializeField] private Transform respawnPoint;

	private float timestamp;
	public int timeBetweenShots = 1; 

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "EnemyBullet" ) {
			health -= 10.0f;
			GameObject expl = Instantiate(explosion, other.transform.position, Quaternion.identity) as GameObject;
			Destroy(expl, 3); 
			if (health <= 0) {			
				Cursor.visible = true;
				DoSceneChange ();
			}

		}
		if (other.tag == "EnemyRifleBullet") {
			health -= 1.0f;
			if (health <= 0) {
				Cursor.visible = true;
				DoSceneChange ();

			}
		}

		if (other.tag == "Mine") {
			health -= 20.0f;
			if (health <= 0) {
				Cursor.visible = true;
				DoSceneChange ();

			}
		}
			
	}

	void Start ()
	{
		Cursor.visible = false;
		maxhealth = health;
	}


	void Update () {
		healthBar.value = CalculateHealth();

		if (isMoving == false) {
			idleSound.Play ();
		}
			
		if(Input.GetKey(KeyCode.W)){
			isMoving = true;
			if (isMoving) {
				movingCar.Play ();
			}

		}
		if(Input.GetKey(KeyCode.S)){
			isMoving = true;
			if (isMoving) {
				movingCar.Play ();
			}	
		}

		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
			isMoving = true;
			if (isMoving) {
				movingCar.Play ();
			}		
		}

		if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)){
			isMoving = true;
			if (isMoving) {
				movingCar.Play ();
			}
		}

		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
			isMoving = true;
			if (isMoving) {
				movingCar.Play ();
			}			
		}
		if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
			isMoving = true;
			if (isMoving) {
				movingCar.Play ();
			}			
		}

		respawnPoint.transform.position = player.transform.position + (new Vector3(0, 5, 0));
		//respawnPoint.transform.rotation = player.transform.rotation;

		if(Input.GetKey(KeyCode.R) && Time.time >= timestamp){
			player.transform.position = respawnPoint.transform.position ;
			player.transform.rotation = Quaternion.Euler(0, 0, 0);
			timestamp = Time.time + timeBetweenShots;

			Debug.Log ("reset");

		}
			
	}


	float CalculateHealth(){
		return health/maxhealth;
	}

	public void DoSceneChange()
	{
		SceneManager.LoadScene(levelToLoad);
	}

}

