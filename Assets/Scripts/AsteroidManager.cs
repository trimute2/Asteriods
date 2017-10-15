using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

	public GameObject Asteroid;

	public int startingNumber;
	public float absentRadius;

	List<GameObject> asteroids;

	public List<GameObject> AsteroidsList{
		get{
			return asteroids;
		}
	}

	// Use this for initialization
	void Start () {
		asteroids = new List<GameObject> ();
		Spawn (startingNumber);
	}

	/// <summary>
	/// Spawn the specified spawnNumber.
	/// </summary>
	/// <param name="spawnNumber">The number of instances to spawn.</param>
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
			newAsteroid.GetComponent<AsteroidScript> ().LevelOneStart ();
			asteroids.Add (newAsteroid);
		}
	}

	/// <summary>
	/// Deystroies an asteroid.
	/// </summary>
	/// <param name="i">The index of the asteroid to be destroyed.</param>
	public void DeystroyAsteroid(int i){
		if (i >= 0 && i < asteroids.Count) {
			Destroy (asteroids [i]);
			asteroids.RemoveAt (i);
		}
	}

	/// <summary>
	/// Destroies an asteroid.
	/// </summary>
	/// <param name="roid">the asteroid to be destroyed.</param>
	public void DestroyAsteroid(GameObject roid){
		if (asteroids.Contains (roid)) {
			asteroids.Remove (roid);
			Destroy (roid);
		}
	}

	/// <summary>
	/// Moves the asteroids.
	/// </summary>
	public void MoveAsteroids(){
		foreach (GameObject roid in asteroids) {
			roid.GetComponent<AsteroidScript> ().Move ();
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (Vector3.zero, absentRadius);
	}
}
