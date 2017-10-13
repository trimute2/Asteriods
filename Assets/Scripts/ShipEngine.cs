using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wraper))]
public class ShipEngine : MonoBehaviour {

	[Range(0f, 5f)]
	public float rateTurn;

	[Range(0f, 5f)]
	public float maxSpeed;

	[Range(0f, 5f)]
	public float rateAcceleration;

	[Range(0f, 1f)]
	public float rateDeceleration;

	Vector3 heading;
	Vector3 velocity;
	Vector3 acceleration;
	bool decelerate;

	Wraper wraper;

	public Quaternion Heading{
		get{
			return Helper.UnitToQuat(heading);
		}
	}


	public Vector3 Position{
		get{
			return this.transform.position;
		}
	}

	void Start () {
		heading = Vector3.right;
		velocity = Vector3.zero;
		acceleration = Vector3.zero;
		wraper = this.GetComponent<Wraper> ();
		decelerate = true;
	}

	public void Turn (float amount){
		float rotationAmount = amount * rateTurn;
		Quaternion angle = Quaternion.Euler (0, 0, -rotationAmount);
		heading = angle * heading;
	}

	public void Thrust (float amount){
		acceleration += heading * (amount * rateAcceleration);
		decelerate = false;
	}

	void Move() {
		Vector3 position = transform.position;
		velocity += acceleration;
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
		position += velocity;
		Quaternion rotation = Helper.UnitToQuat(heading);
		position = wraper.Wrap (position);
		transform.SetPositionAndRotation (position, rotation);

		if (decelerate) {
			velocity *= rateDeceleration;
			acceleration *= rateDeceleration;
		} else {
			decelerate = true;
		}
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}
}
