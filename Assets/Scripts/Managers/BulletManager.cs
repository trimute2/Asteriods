using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	public GameObject bullet;
	public float bulletRate;
	public float bossRate;

	private float bulletTime;
	private float bossTime;
	private List<GameObject> bullets;
	private List<GameObject> bossBullets;

	public List<GameObject> BulletsList{
		get{
			return bullets;
		}
	}

	public List<GameObject> BossBullets{
		get{
			return bossBullets;
		}
	}

	// Use this for initialization
	void Start () {
		bulletTime = 0;
		bullets = new List<GameObject> ();
		bossBullets = new List<GameObject> ();
	}

	/// <summary>
	/// Adds a new bullet.
	/// </summary>
	/// <param name="position">the Position of the new bullet.</param>
	/// <param name="heading">the Heading of the new bullet.</param>
	public void AddBullet(Vector3 position, Quaternion heading){
		if (bulletTime == 0) {
			GameObject newBullet = Instantiate (bullet, position, heading);
			bullets.Add (newBullet);
			bulletTime = bulletRate;
		}
	}

	/// <summary>
	/// Adds a new boss bullet if the current rate is 0.
	/// </summary>
	/// <returns><c>true</c>, if boss bullet was added, <c>false</c> otherwise.</returns>
	/// <param name="position">the Position of the new bullet.</param>
	/// <param name="heading">the Heading of the new bullet.</param>
	public bool AddBossBullet(Vector3 position, Quaternion heading){
		if (bossTime == 0) {
			GameObject newBullet = Instantiate (bullet, position, heading);
			newBullet.GetComponent<SpriteRenderer> ().color = Color.red;
			bossBullets.Add (newBullet);
			bossTime = bossRate;
			return true;
		}
		return false;
	}

	/// <summary>
	/// Ticks the bullet time.
	/// </summary>
	/// <param name="time">the amount of Time to tick.</param>
	public void TickBulletTime(float time){
		if (bulletTime > 0) {
			bulletTime -= time;
			if (bulletTime < 0) {
				bulletTime = 0;
			}
		}
		if (bossTime > 0) {
			bossTime -= time;
			if (bossTime < 0) {
				bossTime = 0;
			}
		}
		foreach (GameObject bullet in bullets) {
			bullet.GetComponent<Projectile> ().TickBulletTime (time);
		}
		foreach (GameObject bullet in bossBullets) {
			bullet.GetComponent<Projectile> ().TickBulletTime (time);
		}
	}

	/// <summary>
	/// Ticks the bullet time by delta time.
	/// </summary>
	public void TickBulletTime(){
		this.TickBulletTime (Time.deltaTime);
	}

	/// <summary>
	/// Checks the bullet list and remove destroyed bullets.
	/// </summary>
	public void CheckBulletList(){
		for (int i = bullets.Count - 1; i >= 0; i--) {
			if (bullets [i] == null) {
				bullets.RemoveAt (i);
			}
		}
		for (int i = bossBullets.Count - 1; i >= 0; i--) {
			if (bossBullets [i] == null) {
				bossBullets.RemoveAt (i);
			}
		}
	}

	public void DestroyBullet(int i){
		Destroy (bullets [i]);
		bullets.RemoveAt (i);
	}

	public void DestroyBossBullets(int i){
		Destroy (bossBullets [i]);
		bossBullets.RemoveAt (i);
	}

	/// <summary>
	/// Moves the bullets.
	/// </summary>
	public void MoveBullets(){
		foreach (GameObject bullet in bullets) {
			bullet.GetComponent<Projectile> ().Move ();
		}
		foreach (GameObject bullet in bossBullets) {
			bullet.GetComponent<Projectile> ().Move ();
		}
	}

}
