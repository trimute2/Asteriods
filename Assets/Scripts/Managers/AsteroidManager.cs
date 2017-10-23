using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidManager : MonoBehaviour {

	public GameObject Asteroid;
	public GUIManager guiManager;

	public int startingNumber;
	public float absentRadius;

	public string winScene;

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
	public void DestroyAsteroid(int i){
		if (i >= 0 && i < asteroids.Count) {
			DestroyAsteroid(asteroids[i]);
		}
	}

	/// <summary>
	/// Destroies an asteroid.
	/// </summary>
	/// <param name="roid">the asteroid to be destroyed.</param>
	public void DestroyAsteroid(GameObject roid){
		if (asteroids.Contains (roid)) {
			if (roid.GetComponent<AsteroidScript> ().Level == 1) {
				float variance = Random.Range (0f, 5f);
				GameObject newAstoroidOne = Instantiate (Asteroid, roid.transform.position, Quaternion.AngleAxis (Random.Range (0f, 360f), Vector3.forward));
				GameObject newAstoroidTwo = Instantiate (Asteroid, roid.transform.position, Quaternion.AngleAxis (Random.Range (0f, 360f), Vector3.forward));
				//float angle = Mathf.Acos (roid.GetComponent<AsteroidScript> ().Velocity.x)*Mathf.Rad2Deg;
				Vector3 vel = roid.GetComponent<AsteroidScript> ().Velocity;
				float angle = Mathf.Atan2 (vel.y, vel.x) * Mathf.Rad2Deg;
				newAstoroidOne.GetComponent<AsteroidScript> ().LevelTwoStart (angle + variance);
				newAstoroidTwo.GetComponent<AsteroidScript> ().LevelTwoStart (angle - variance);
				asteroids.Add (newAstoroidOne);
				asteroids.Add (newAstoroidTwo);
				guiManager.IncrementScore (20);
			} else {
				guiManager.IncrementScore (50);
			}
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

	public void checkWin(){
		if (asteroids.Count == 0) {
			SceneManager.LoadScene (winScene);
		}
	}
}
