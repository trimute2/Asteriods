using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

	public GameObject Ship;
	public BulletManager bulletManager;
	public AsteroidManager asteroidManager;

	// Use this for initialization
	void Start () {
		
	}

	/// <summary>
	/// Collides the asteroids with the bullets.
	/// </summary>
	public void CollideAsteroidsBullets(){
		List<GameObject> asteroids = asteroidManager.AsteroidsList;
		List<GameObject> bullets = bulletManager.BulletsList;

		for (int i = asteroids.Count - 1; i >= 0; i--) {
			CollisionCircle curr = asteroids [i].GetComponent<CollisionCircle> ();
			for (int j = bullets.Count - 1; j >= 0; j--) {
				if(curr.TestCollisionCircle(bullets[j].GetComponent<CollisionCircle>())){
					asteroidManager.DeystroyAsteroid (i);
					bulletManager.DestroyBullet (j);
					j = -1;
					Debug.Log (bullets.Count);
				}
			}
		}
	}

	/// <summary>
	/// Collides the ship with the asteroids.
	/// </summary>
	public void CollideShipAsteroids(){

	}
}
