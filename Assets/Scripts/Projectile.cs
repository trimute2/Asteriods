﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wraper))]
public class Projectile : MonoBehaviour {

	[Range(0f, 5f)]
	public float speed;

	public float bulletLifeSpan = 10;

	Wraper wraper;
	Vector3 velocity;
	private float bulletTime;
	private bool started;

	public Vector3 Velocity{
		get{
			return velocity;
		}
	}
	void Awake(){
		//this is so that i dont get some weird errors
		started = false;
		bulletTime = float.MaxValue;
	}

	// Use this for initialization
	void Start () {
		wraper = this.GetComponent<Wraper> ();
		bulletTime = bulletLifeSpan;
		velocity = transform.right.normalized * speed;
		started = true;
	}

	/// <summary>
	/// Ticks the bullet time. When bullet time reaches zero the bullet is destroyed.
	/// </summary>
	/// <param name="time">the amount of Time to tick.</param>
	public void TickBulletTime(float time){
		bulletTime -= Time.deltaTime;
		if (bulletTime <= 0) {
			Destroy (this.gameObject);
		}
	}

	/// <summary>
	/// Ticks the bullet time by delta time. When bullet time reaches zero the bullet is destroyed.
	/// </summary>
	public void TickBulletTime(){
		TickBulletTime (Time.deltaTime);
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
	public void Move(){
		if (started) {
			Vector3 position = this.transform.position;
			position += velocity;
			position = wraper.Wrap (position);
			transform.position = position;
		}
	}

}
