using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wraper))]
public class AsteroidScript : MonoBehaviour {

	[Range(0f, 5f)]
	public float minSpeed;

	[Range(0f, 5f)]
	public float maxSpeed;

	Vector3 velocity;
	Wraper wraper;

	void Start () {
		float angle = Random.Range (0f, 360f);
		velocity = Helper.DegreeToVector3 (angle);
		velocity = velocity.normalized * Random.Range (minSpeed, maxSpeed);
		wraper = this.GetComponent<Wraper> ();
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
	public void Move(){
		Vector3 position = this.transform.position;
		position += velocity;
		position = wraper.Wrap (position);
		this.transform.position = position;
	}

	void Update () {
		Move();
	}
}
