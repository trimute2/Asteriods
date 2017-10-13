using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[Range(0f, 5f)]
	public float speed;

	public float bulletLifeSpan = 10;

	Wraper wraper;
	Vector3 velocity;
	private float bulletTime;
	// Use this for initialization
	void Start () {
		bulletTime = bulletLifeSpan;
		wraper = this.GetComponent<Wraper> ();
		velocity = transform.right.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
		bulletLifeSpan -= Time.deltaTime;
		if (bulletLifeSpan <= 0) {
			Destroy (this.gameObject);
		}
		Vector3 position = this.transform.position;
		position += velocity;
		position = wraper.Wrap (position);
		transform.position = position;
	}
}
