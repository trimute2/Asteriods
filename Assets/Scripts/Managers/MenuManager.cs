using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void LoadAsteroidLevel(){
		SceneManager.LoadScene ("Asteroid");
	}

	public void LoadBossLevel(){
		SceneManager.LoadScene ("Boss");
	}
}
