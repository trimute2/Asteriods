using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

	public GameObject Asteroid;

	public int startingNumber;
	public float absentRadius;

	List<GameObject> Asteroids;
	// Use this for initialization
	void Start () {
		Asteroids = new List<GameObject> ();
		Spawn (startingNumber);
	}

	void Spawn(int spawnNumber){
		Vector3 max = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height));
		Vector3 min = Camera.main.ScreenToWorldPoint (Vector3.zero);
		for (int i = 0; i < spawnNumber; i++) {
			Vector3 position = Vector3.zero;
			do {
				position.x = Random.Range (min.x, max.x);
				position.y = Random.Range (min.y, max.y);
			} while(position.sqrMagnitude < absentRadius * absentRadius);
			float angle = Random.Range (0f, 360f);
			GameObject newAsteroid = Instantiate (Asteroid, position, Quaternion.AngleAxis(angle,Vector3.forward));
			Asteroids.Add (newAsteroid);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (Vector3.zero, absentRadius);
	}
}
