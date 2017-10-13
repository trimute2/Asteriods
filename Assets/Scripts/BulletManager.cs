using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	public GameObject bullet;
	public float bulletRate;

	private float bulletTime;
	private List<GameObject> bullets;
	// Use this for initialization
	void Start () {
		bulletTime = 0;
		bullets = new List<GameObject> ();
	}

	public void AddBullet(Vector3 position, Quaternion heading){
		if (bulletTime == 0) {
			GameObject newBullet = Instantiate (bullet, position, heading);
			bullets.Add (newBullet);
			bulletTime = bulletRate;
		}
	}

	// Update is called once per frame
	void Update () {
		if (bulletTime > 0) {
			bulletTime -= Time.deltaTime;
			if (bulletTime < 0) {
				bulletTime = 0;
			}
		}
		for (int i = bullets.Count - 1; i > 0; i--) {
			if (bullets [i] == null) {
				bullets.RemoveAt (i);
			}
		}
	}
}
