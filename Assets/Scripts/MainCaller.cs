using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCaller : MonoBehaviour {

	public GameObject ship;
	public CollisionManager collisionManager;
	public BulletManager bulletManager;
	public AsteroidManager asteroidManager;

	ShipEngine engine;

	// Use this for initialization
	void Start () {
		engine = ship.GetComponent<ShipEngine> ();
	}
	
	// Update is called once per frame
	void Update () {
		bulletManager.CheckBulletList ();
		bulletManager.MoveBullets ();
		engine.Move();
		asteroidManager.MoveAsteroids ();
		collisionManager.CollideAsteroidsBullets ();
		bulletManager.TickBulletTime ();
	}
}
