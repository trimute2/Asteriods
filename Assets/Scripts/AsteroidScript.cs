﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wraper))]
public class AsteroidScript : MonoBehaviour {

	[Range(0f, 5f)]
	public float minSpeed;

	[Range(0f, 5f)]
	public float maxSpeed;

	public List<Sprite> shapes;

	Vector3 velocity;
	Wraper wraper;
	int level;

	public int Level{
		get{
			return level;
		}
	}

	public Vector3 Velocity{
		get{
			return velocity;
		}
	}
	/// <summary>
	/// the start called for all instances
	/// </summary>
	void Start () {
		Sprite s = shapes [Random.Range (0, shapes.Count)];
		this.GetComponent<SpriteRenderer> ().sprite = s;
		wraper = this.GetComponent<Wraper> ();
	}

	/// <summary>
	/// The start called for level one asteroids
	/// </summary>
	public void LevelOneStart(){
		this.level = 1;
		float angle = Random.Range (0f, 360f);
		this.velocity = Helper.DegreeToVector3 (angle);
		this.velocity = velocity.normalized * Random.Range (minSpeed, maxSpeed);
	}

	/// <summary>
	/// The start called for level two asteroids
	/// </summary>
	public void LevelTwoStart(float angle){
		level = 2;
		this.velocity = Helper.DegreeToVector3 (angle);
		this.velocity = velocity.normalized * Random.Range (minSpeed, maxSpeed);
		this.GetComponent<CollisionCircle> ().radius *= 0.5f;
		transform.localScale *= 0.5f;
		this.GetComponent<CollisionCircle> ().radius *= 0.5f;
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
	public void Move(){
		Vector3 position = this.transform.position;
		position += velocity;
		if (wraper != null) {
			position = wraper.Wrap (position);
		}
		this.transform.position = position;
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube (this.transform.position, this.GetComponent<SpriteRenderer> ().bounds.size);
	}
}
