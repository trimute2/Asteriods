using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCaller : MonoBehaviour {

	public GameObject ship;
	public GameObject boss;
	public CollisionManager collisionManager;
	public BulletManager bulletManager;
	public AsteroidManager asteroidManager;

	bool bossFight;
	bool asteroidFight;
	ShipEngine engine;
	HealthManager health;
	BossScript sBoss;

	// Use this for initialization
	void Start () {
		engine = ship.GetComponent<ShipEngine> ();
		health = ship.GetComponent<HealthManager> ();
		bossFight = (boss != null);
		if (bossFight) {
			sBoss = boss.GetComponent<BossScript> ();
		}
		asteroidFight = (asteroidManager != null);
	}
	
	// Update is called once per frame
	void Update () {
		bulletManager.CheckBulletList ();
		bulletManager.MoveBullets ();
		engine.Move ();
		if (bossFight) {
			collisionManager.CollideShipBossBullets ();
			collisionManager.CollideBossBullets ();
		}

		if(asteroidFight) {
			asteroidManager.MoveAsteroids ();
			collisionManager.CollideAsteroidsBullets ();
			collisionManager.CollideShipAsteroids ();
		}
		bulletManager.TickBulletTime ();
		health.TickImmunityTime ();
	}
}
