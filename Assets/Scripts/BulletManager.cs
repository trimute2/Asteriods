using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	public GameObject bullet;
	public float bulletRate;

	private float bulletTime;
	private List<GameObject> bullets;

	public List<GameObject> BulletsList{
		get{
			return bullets;
		}
	}
	// Use this for initialization
	void Start () {
		bulletTime = 0;
		bullets = new List<GameObject> ();
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
		foreach (GameObject bullet in bullets) {
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
	}

	public void DestroyBullet(int i){
		Destroy (bullets [i]);
		bullets.RemoveAt (i);
	}

	/// <summary>
	/// Moves the bullets.
	/// </summary>
	public void MoveBullets(){
		foreach (GameObject bullet in bullets) {
			bullet.GetComponent<Projectile> ().Move ();
		}
	}

	// Update is called once per frame
	/*void Update () {
		TickBulletTime ();
		CheckBulletList ();
	}*/
}
