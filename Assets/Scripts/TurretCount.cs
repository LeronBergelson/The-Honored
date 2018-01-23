using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurretCount : MonoBehaviour {
	public Text numberOfEnemies;
	[SerializeField] string levelToLoad;

	int numOfTurrets;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		numOfTurrets = GameObject.FindGameObjectsWithTag("Enemy").Length;
		numberOfEnemies.text = numOfTurrets.ToString();
		if(numOfTurrets == 0){
			Cursor.visible = true;
			DoSceneChange ();

	}
	}

		public void DoSceneChange()
		{
			SceneManager.LoadScene(levelToLoad);
		}
}
