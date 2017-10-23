using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

	public UnityEngine.UI.Text textElement;
	public UnityEngine.UI.Text scoreElement;
	public HealthManager healthManager;

	bool scoreUsed;

	int score;
	int lives;

	// Use this for initialization
	void Start () {
		scoreUsed = (scoreElement != null);
		score = 0;
		IncrementScore (0);
		UpdateLives ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lives != healthManager.lives) {
			UpdateLives ();
		}
	}

	void UpdateLives(){
		lives = healthManager.lives;
		textElement.text = "Lives:" + lives.ToString ();
	}

	public void IncrementScore(int val){
		if (scoreUsed) {
			score += val;
			scoreElement.text = "Score: " + score.ToString ();
		}
	}

}
