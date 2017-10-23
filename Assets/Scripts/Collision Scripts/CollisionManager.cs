using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

	public GameObject Ship;
	public GameObject Boss;
	public BulletManager bulletManager;
	public AsteroidManager asteroidManager;

	/// <summary>
	/// Handles collisions between asteroids and the players bullets.
	/// </summary>
	public void CollideAsteroidsBullets(){
		//get the asteroids and the players bullets
		List<GameObject> asteroids = asteroidManager.AsteroidsList;
		List<GameObject> bullets = bulletManager.BulletsList;
		//loop through the asteroids
		for (int i = asteroids.Count - 1; i >= 0; i--) {
			//get the asteroids collision circle then loop through the bullets
			CollisionCircle curr = asteroids [i].GetComponent<CollisionCircle> ();
			for (int j = bullets.Count - 1; j >= 0; j--) {
				//check for collision
				if(curr.TestCollisionCircle(bullets[j].GetComponent<CollisionCircle>())){
					//if there is a collision destroy both the asteroid and the bullet then and stop looping through bullets
					asteroidManager.DestroyAsteroid (asteroids[i]);
					bulletManager.DestroyBullet (j);
					j = -1;
				}
			}
		}
	}

	/// <summary>
	/// Handles collisions between the ship and asteroids.
	/// </summary>
	public void CollideShipAsteroids(){
		//get the players health script
		HealthManager health = Ship.GetComponent<HealthManager> ();
		//check if the player currently has immunity
		if (!health.Immune) {
			//get the asteroids and the ships collision circle
			List<GameObject> asteroids = asteroidManager.AsteroidsList;
			CollisionCircle shipCollider = Ship.GetComponent<CollisionCircle> ();
			//loop through the asteroids
			for (int i = asteroids.Count - 1; i >= 0; i--) {
				//check for collision
				if (shipCollider.TestCollisionCircle (asteroids [i].GetComponent<CollisionCircle> ())) {
					//if there is a collision damage the ship
					health.Hit ();
				}
			}
		}
	}

	/// <summary>
	/// Handle collisions between the player and the bosses bullets
	/// </summary>
	public void CollideShipBossBullets(){
		HealthManager health = Ship.GetComponent<HealthManager> ();
		List<GameObject> bullets = bulletManager.BossBullets;
		CollisionCircle shipCollider = Ship.GetComponent<CollisionCircle> ();
		if (!health.Immune) {
			for (int i = bullets.Count - 1; i >= 0; i--) {
				if (shipCollider.TestCollisionCircle (bullets [i].GetComponent<CollisionCircle> ())) {
					health.Hit ();
					bulletManager.DestroyBossBullets (i);
				}
			}
		}
	}


	/// <summary>
	/// Handle collisions between the boss and the players bullets
	/// </summary>
	public void CollideBossBullets(){
		HealthManager health = Boss.GetComponent<HealthManager> ();
		List<GameObject> bullets = bulletManager.BulletsList;
		CollisionCircle bossCollider = Boss.GetComponent<CollisionCircle> ();
		if (!health.Immune) {
			for (int i = bullets.Count - 1; i >= 0; i--) {
				if (bossCollider.TestCollisionCircle (bullets [i].GetComponent<CollisionCircle> ())) {
					health.Hit ();
					bulletManager.DestroyBullet (i);
				}
			}
		}
	}
}
