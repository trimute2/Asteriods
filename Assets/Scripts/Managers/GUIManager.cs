using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

	public UnityEngine.UI.Text textElement;
	public HealthManager healthManager;


	int lives;

	// Use this for initialization
	void Start () {
		lives = healthManager.lives;
		textElement.text = "Lives:" + lives.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lives != healthManager.lives) {
			lives = healthManager.lives;
			textElement.text = "Lives:" + lives.ToString ();
		}
	}

}
