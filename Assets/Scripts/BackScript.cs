using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour {
	[SerializeField] string levelToLoad;

	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.Escape)) {
			DoSceneChange ();
		}
	}

	public void DoSceneChange()
	{
		SceneManager.LoadScene(levelToLoad);
	}
}
